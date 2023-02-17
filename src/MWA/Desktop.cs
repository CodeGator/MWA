
namespace MWA;

/// <summary>
/// This class utility contains desktop related logic.
/// </summary>
internal static class Desktop
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
        public const int READ_CONTROL = 0x20000;

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr OpenInputDesktop(uint dwFlags, bool fInherit,
           uint dwDesiredAccess
            );

        [DllImport("user32.dll", EntryPoint = "CloseDesktop", CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CloseDesktop(
            IntPtr handle
            );
    }

    #endregion

    // *******************************************************************
    // Public methods.
    // *******************************************************************

    #region Public methods

    /// <summary>
    /// This method indicates whether the desktop is locked (at the lock screen).
    /// </summary>
    /// <returns><c>True</c> if the desktop is locked, <c>False</c> otherwise.</returns>
    public static bool IsLocked()
    {
        var handle = IntPtr.Zero;
        try
        {
            // Can we open the input desktop?
            handle = NativeMethods.OpenInputDesktop(
                0,
                false,
                NativeMethods.READ_CONTROL
                );

            // If not, we're locked.
            return handle == IntPtr.Zero;
        }
        finally
        {
            // If we got a handle, clean it up.
            if (handle != IntPtr.Zero)
            {
                NativeMethods.CloseDesktop(handle);
            }
        }
    }

    #endregion
}
