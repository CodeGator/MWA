
using System.Reflection;

namespace MWA.Forms;

/// <summary>
/// This class is the code-behind for the <see cref="AboutForm"/> form.
/// </summary>
public partial class AboutForm : Form
{
    // *******************************************************************
    // Constructors.
    // *******************************************************************

    #region Constructors

    /// <summary>
    /// This constructor creates a new instance of the <see cref="AboutForm"/>
    /// class.
    /// </summary>
    public AboutForm()
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
        // Set the title.
        label1.Text = "About: " + typeof(AboutForm).Assembly.ReadTitle() +
            "  Version [" + typeof(AboutForm).Assembly.ReadInformationalVersion() +
            "]";

        // Set the description.
        label2.Text = typeof(AboutForm).Assembly.ReadDescription();

        // Set the copyright.
        label3.Text = typeof(AboutForm).Assembly.ReadCopyright();

        // Give the base class a chance.
        base.OnLoad(e);
    }

    #endregion

    // *******************************************************************
    // Private methods.
    // *******************************************************************

    #region Private methods


    #endregion
}
