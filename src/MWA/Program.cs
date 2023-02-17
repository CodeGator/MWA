namespace MWA;

/// <summary>
/// This class contains the main entry point for the application.
/// </summary>
internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // Only run 1 instance at a time.
        using (Mutex mutex = new Mutex(false, @"{FB8F6979-E303-4C07-8C41-39308BF79707}"))
        {
            // Is another instance running?
            if (!mutex.WaitOne(0, false))
            {
                return; // Just exit.
            }

            // Configure the winforms app to run.
            ApplicationConfiguration.Initialize();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                // Set the mouse hook.
                Mouse.SetHook();

                // Run the application.
                Application.Run(new MainForm());
            }
            finally
            {
                // Cleanup the mouse hook.
                Mouse.RemoveHook();
            }
        }
    }
}