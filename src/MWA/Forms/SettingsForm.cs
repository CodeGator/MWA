
namespace MWA.Forms;

/// <summary>
/// This class is the code-behind for the <see cref="SettingsForm"/> form.
/// </summary>
public partial class SettingsForm : Form
{
    // *******************************************************************
    // Constructors.
    // *******************************************************************

    #region Constructors

    /// <summary>
    /// This constructor creates a new instance of the <see cref="SettingsForm"/>
    /// class.
    /// </summary>
    public SettingsForm()
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
    /// This method is called to load the form.
    /// </summary>
    /// <param name="e">The event arguments.</param>
    protected override void OnLoad(EventArgs e)
    {
        // Set the UI.
        stopOnLockCheckBox.Checked = Settings.Default.StopOnLock;
        maxElapsedTrackBar.Value = Settings.Default.MaxElapsed;
        stopMouseWigglingCheckBox.Checked = Settings.Default.StopAll;

        // Give the base class a chance.
        base.OnLoad(e);
    }

    // *******************************************************************

    /// <summary>
    /// This method is called to close the form.
    /// </summary>
    /// <param name="e"></param>
    protected override void OnClosed(EventArgs e)
    {
        // Did the user save the changes?
        if (DialogResult == DialogResult.OK)
        {
            // Save any changes.
            Settings.Default.Save();
        }
        else
        {
            // Don't save any changes.
            Settings.Default.Reload();
        }

        // Give the base class a chance.
        base.OnClosed(e);
    }

    #endregion

    // *******************************************************************
    // Private methods.
    // *******************************************************************

    #region Private methods

    /// <summary>
    /// This method is called when the max elapsed setting changes.
    /// </summary>
    /// <param name="sender">The event sender.</param>
    /// <param name="e">The event arguments.</param>
    private void maxElapsedTrackBar_ValueChanged(
        object sender,
        EventArgs e
        )
    {
        // Set the setting.
        Settings.Default.MaxElapsed = (int)maxElapsedTrackBar.Value;

        // Update the helper text.
        if (Settings.Default.MaxElapsed > 1)
        {
            maxElapsedLabel.Text = "Max minutes between mouse wiggles " +
                $"(currently: {Settings.Default.MaxElapsed} minutes)";
        }
        else
        {
            maxElapsedLabel.Text = "Max minutes between mouse wiggles " +
                $"(currently: {Settings.Default.MaxElapsed} minute)";
        }
    }

    // *******************************************************************

    /// <summary>
    /// This method is called when the 'stop on lock' checkbox is changed.
    /// </summary>
    /// <param name="sender">The event sender.</param>
    /// <param name="e">The event arguments.</param>
    private void stopOnLockCheckBox_CheckedChanged(
        object sender,
        EventArgs e
        )
    {
        // Set the setting.
        Settings.Default.StopOnLock = stopOnLockCheckBox.Checked;
    }

    // *******************************************************************

    /// <summary>
    /// This method is called when the 'stop all wiggling' checkbox is changed.
    /// </summary>
    /// <param name="sender">The event sender.</param>
    /// <param name="e">The event arguments.</param>
    private void stopMouseWigglingCheckBox_CheckedChanged(
        object sender, 
        EventArgs e
        )
    {
        // Set the setting.
        Settings.Default.StopAll = stopMouseWigglingCheckBox.Checked;
    }

    #endregion
}
