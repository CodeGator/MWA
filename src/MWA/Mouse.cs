
namespace MWA
{
    /// <summary>
    /// This class utility contains mouse related logic.
    /// </summary>
    public static class Mouse
    {
        // *******************************************************************
        // Types.
        // *******************************************************************

        #region Types

        /// <summary>
        /// This class utility contains native WIN32 methods and structures.
        /// </summary>
        static class NativeMethods
        {
            public const int WH_MOUSE_LL = 14;

            [StructLayout(LayoutKind.Explicit)]
            public struct INPUT
            {
                [FieldOffset(0)]
                public int type;
                [FieldOffset(4)]
                public MOUSEINPUT mi;
                [FieldOffset(4)]
                public KEYBDINPUT ki;
                [FieldOffset(4)]
                public HARDWAREINPUT hi;
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct HARDWAREINPUT
            {
                public int uMsg;
                public short wParamL;
                public short wParamH;
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct MOUSEINPUT
            {
                public int dx;
                public int dy;
                public int mouseData;
                public int dwFlags;
                public int time;
                public IntPtr dwExtraInfo;
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct KEYBDINPUT
            {
                public short wVk;
                public short wScan;
                public int dwFlags;
                public int time;
                public IntPtr dwExtraInfo;
            }

            [Flags()]
            public enum MOUSEEVENTF
            {
                MOVE = 0x0001,  // mouse move 
                LEFTDOWN = 0x0002,  // left button down
                LEFTUP = 0x0004,  // left button up
                RIGHTDOWN = 0x0008,  // right button down
                RIGHTUP = 0x0010,  // right button up
                MIDDLEDOWN = 0x0020,  // middle button down
                MIDDLEUP = 0x0040,  // middle button up
                XDOWN = 0x0080,  // x button down 
                XUP = 0x0100,  // x button down
                WHEEL = 0x0800,  // wheel button rolled
                VIRTUALDESK = 0x4000,  // map to entire virtual desktop
                ABSOLUTE = 0x8000,  // absolute move
            }

            [DllImport("user32.dll", EntryPoint = "SendInput", SetLastError = true)]
            public static extern uint SendInput(
                uint nInputs, INPUT[] 
                pInputs, int cbSize
                );

            public enum MouseMessages
            {
                WM_LBUTTONDOWN = 0x0201,
                WM_LBUTTONUP = 0x0202,
                WM_MOUSEMOVE = 0x0200,
                WM_MOUSEWHEEL = 0x020A,
                WM_RBUTTONDOWN = 0x0204,
                WM_RBUTTONUP = 0x0205
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct POINT
            {
                public int x;
                public int y;
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct MSLLHOOKSTRUCT
            {
                public POINT pt;
                public uint mouseData;
                public uint flags;
                public uint time;
                public IntPtr dwExtraInfo;
            }

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern IntPtr SetWindowsHookEx(int idHook,
                LowLevelMouseProc lpfn, IntPtr hMod, uint dwThreadId);

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool UnhookWindowsHookEx(IntPtr hhk);

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
                IntPtr wParam, IntPtr lParam);

            [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern IntPtr GetModuleHandle(string lpModuleName);
        }

        #endregion

        // *******************************************************************
        // Fields.
        // *******************************************************************

        #region Fields

        /// <summary>
        /// This delegate is the callback type for the mouse hook.
        /// </summary>
        /// <param name="nCode">The message code.</param>
        /// <param name="wParam">The message wParam.</param>
        /// <param name="lParam">Thge message lParam</param>
        /// <returns>The results of the message.</returns>
        private delegate IntPtr LowLevelMouseProc(
            int nCode, 
            IntPtr wParam, 
            IntPtr lParam
            );

        /// <summary>
        /// This field contains the mouse hook handle.
        /// </summary>
        private static IntPtr _hookID = IntPtr.Zero;

        /// <summary>
        /// This field contains the mouse hook callback.
        /// </summary>
        private static LowLevelMouseProc _hookProc = HookCallback;

        /// <summary>
        /// This field backs the <see cref="Mouse.LastMouseMove"/> property.
        /// </summary>
        public static DateTime _lastMouseMove = DateTime.Now;

        #endregion

        // *******************************************************************
        // Properties.
        // *******************************************************************

        #region Properties

        /// <summary>
        /// This property contains the last date/time when the mouse moved.
        /// </summary>
        public static DateTime LastMouseMove => _lastMouseMove;

        #endregion

        // *******************************************************************
        // Public methods.
        // *******************************************************************

        #region Public methods

        /// <summary>
        /// This method moves the mouse.
        /// </summary>
        /// <param name="x">The X coordinate to move to.</param>
        /// <param name="y">The Y coordinate to move to.</param>
        public static void Move(int x, int y)
        {
            // Is there a screen?
            if (Screen.PrimaryScreen is not null)
            {
                // Get the current screen dimensions.
                var screenWidth = Screen.PrimaryScreen.Bounds.Width;
                var screenHeight = Screen.PrimaryScreen.Bounds.Height;
                
                // Manufacture a move message.
                var input_move = new NativeMethods.INPUT();
                input_move.mi.dx = (int)Math.Round((double)x * (65535 / screenWidth), 0);
                input_move.mi.dy = (int)Math.Round((double)y * (65535 / screenHeight), 0);
                input_move.mi.mouseData = 0;
                input_move.mi.dwFlags = (int)(NativeMethods.MOUSEEVENTF.MOVE |
                    NativeMethods.MOUSEEVENTF.ABSOLUTE
                    );
                NativeMethods.INPUT[] input = { input_move };

                // Send the move message.
                NativeMethods.SendInput(
                    1, 
                    input, 
                    Marshal.SizeOf(input_move)
                    );
            }
        }

        // *******************************************************************

        /// <summary>
        /// This method sets a mouse hook.
        /// </summary>
        public static void SetHook()
        {
            // Is there already a hook?
            if (_hookID != IntPtr.Zero)
            {
                // Cleanup the hook.
                RemoveHook();
            }

            // Create the hook.
            _hookID = SetHook(_hookProc);
        }

        // *******************************************************************

        /// <summary>
        /// This method cleans up a mouse hook.
        /// </summary>
        public static void RemoveHook()
        {
            // Remove the mouse hook.
            NativeMethods.UnhookWindowsHookEx(_hookID);

            // Clear the handle.
            _hookID = IntPtr.Zero;
        }

        #endregion

        // *******************************************************************
        // Private methods.
        // *******************************************************************

        #region Private methods

        /// <summary>
        /// This method is the hook procedure.
        /// </summary>
        /// <param name="nCode">The message code.</param>
        /// <param name="wParam">The message wParam.</param>
        /// <param name="lParam">Thge message lParam</param>
        /// <returns>The results of the message.</returns>
        private static IntPtr HookCallback(
            int nCode,
            IntPtr wParam,
            IntPtr lParam
            )
        {
            // Is this a mouse move message?
            if ((NativeMethods.MouseMessages)wParam == NativeMethods.MouseMessages.WM_MOUSEMOVE)
            {
                _lastMouseMove = DateTime.Now;
            }

            // Call the next hook.
            return NativeMethods.CallNextHookEx(
                _hookID,
                nCode,
                wParam,
                lParam
                );
        }

        // *******************************************************************

        /// <summary>
        /// This method creates a low-level mouse hook.
        /// </summary>
        /// <param name="proc">The procedure for the hook.</param>
        /// <returns>The handle of the hook.</returns>
        private static IntPtr SetHook(LowLevelMouseProc proc)
        {
            // Get the current processs.
            using var curProcess = Process.GetCurrentProcess();

            // Get the current module.
            using var curModule = curProcess.MainModule;
            
            // Did we succeed?
            if (curModule is not null)
            {
                // Create the hook.
                return NativeMethods.SetWindowsHookEx(
                    NativeMethods.WH_MOUSE_LL,
                    proc,
                    NativeMethods.GetModuleHandle(curModule.ModuleName),
                    0
                    );
            }

            // No hook for you!!
            return IntPtr.Zero;
        }

        #endregion
    }
}
