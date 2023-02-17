
namespace MWA.Forms
{
    /// <summary>
    /// This class is the code-behind for the <see cref="MainForm"/> form.
    /// </summary>
    public partial class MainForm : Form
    {
        // *******************************************************************
        // Fields.
        // *******************************************************************

        #region Fields

        /// <summary>
        /// This field determines whether or not to show the window.
        /// </summary>
        internal protected bool _allowShowDisplay;

        #endregion

        // *******************************************************************
        // Constructors.
        // *******************************************************************

        #region Constructors

        /// <summary>
        /// This constructor creates a new instance of the <see cref="MainForm"/>
        /// class.
        /// </summary>
        public MainForm()
        {
            // Make the designer happy.
            InitializeComponent();
        }

        #endregion

        // *******************************************************************
        // Protected methods.
        // *******************************************************************

        #region Protected methods

        /// <summary>
        /// This method is called to close the form.
        /// </summary>
        /// <param name="e">The event arguments.</param>
        protected override void OnClosed(EventArgs e)
        {
            try
            {
                // Hide the system tray icon.
                notifyIcon1.Visible = false;

                // Give the base class a chance.
                base.OnClosed(e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "MWA",
                    "Failed to close the main form!"
                    );
            }
        }

        // *******************************************************************

        /// <summary>
        /// This method sets the window to the specified visible state.
        /// </summary>
        /// <param name="value"><c>True</c> to show the window, <c>False</c> to
        /// hide it.</param>
        protected override void SetVisibleCore(bool value)
        {
            try
            {
                // Update the system tray icon title.
                notifyIcon1.Text = $"MWA " +
                    typeof(MainForm).Assembly.ReadInformationalVersion();

                // Give the base class a chance.
                base.SetVisibleCore(
                    _allowShowDisplay ? value : _allowShowDisplay
                    );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "MWA",
                    "Failed to set the visible core!"
                    );
            }
        }

        #endregion

        // *******************************************************************
        // Private methods.
        // *******************************************************************

        #region Private methods

        /// <summary>
        /// This method is the handler for the timer tick event.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void timer1_Tick(
            object sender,
            EventArgs e
            )
        {
            try
            {
                // Is wiggling disabled?
                if (Settings.Default.StopAll)
                {
                    return; // Do nothing.
                }

                // Are we configured to stop wiggling when the desktop is locked?
                if (Settings.Default.StopOnLock)
                {
                    // Is the desktop locked?
                    if (Desktop.IsLocked())
                    {
                        return; // Do nothing.
                    }
                }

                // Has it been too long since we wiggled the mouse?
                if (DateTime.Now.Subtract(Mouse.LastMouseMove).TotalMinutes >= Settings.Default.MaxElapsed)
                {
                    // Change the system try icon.
                    notifyIcon1.Icon = Resources.wi0010_48;

                    // Get the starting position of the mouse.
                    var oldPos = MousePosition;

                    // Wiggle three times.
                    for (int x = 0; x < 3; x++)
                    {
                        // Wiggle baby!!
                        Mouse.Move(oldPos.X, oldPos.Y + x);

                        // Delay between wiggles.
                        //Task.Delay(2).Wait();
                    }

                    // Move back to the starting position.
                    Mouse.Move(oldPos.X, oldPos.Y);
                }
            }
            catch (Exception ex)
            {
                // TODO : decide what to do here.
            }
        }

        // *******************************************************************

        /// <summary>
        /// This method is the handler exit menu.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void fileToolStripMenuItem_Click(
            object sender,
            EventArgs e
            )
        {
            // Close the application.
            Application.Exit();
        }

        // *******************************************************************

        /// <summary>
        /// This method is the handler for the settings menu.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void settingsToolStripMenuItem_Click(
            object sender,
            EventArgs e
            )
        {
            try
            {
                // Disable the menu item.
                settingsToolStripMenuItem.Enabled = false;

                // Show the form.
                var form = new SettingsForm();
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "MWA",
                    "Failed to show the setting form!"
                    );
            }
            finally
            {
                // Enable the menu item.
                settingsToolStripMenuItem.Enabled = true;
            }
        }

        // *******************************************************************

        /// <summary>
        /// This method is the handler for the about menu.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void aboutToolStripMenuItem_Click(
            object sender,
            EventArgs e
            )
        {
            try
            {
                // Disable the menu item.
                aboutToolStripMenuItem.Enabled = false;

                // Show the form.
                new AboutForm().ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "MWA",
                    "Failed to show the setting form!"
                    );
            }
            finally
            {
                // Enable the menu item.
                aboutToolStripMenuItem.Enabled = true;
            }
        }

        #endregion
    }
}