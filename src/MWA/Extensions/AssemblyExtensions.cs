﻿
namespace System.Reflection;

/// <summary>
/// This class contains extension methods related to the <see cref="Assembly"/>
/// type.
/// </summary>
internal static partial class AssemblyExtensions
{
    // *******************************************************************
    // Public methods.
    // *******************************************************************

    #region Public methods

    /// <summary>
    /// Reads the value of the <see cref="AssemblyCompanyAttribute"/>
    /// attribute for the given assembly.
    /// </summary>
    /// <param name="assembly">The assembly to read from.</param>
    /// <returns>The value of the given assembly's company attribute.</returns>
    public static string ReadCompany(this Assembly assembly)
    {
        // Attempt to read the assembly's company attribute.
        object[] attributes = assembly.GetCustomAttributes(
            typeof(AssemblyCompanyAttribute),
            true
            );

        // Did we fail?
        if (attributes.Length == 0)
            return string.Empty;

        // Attempt to recover a reference to the attribute.
        var attr = attributes[0] as AssemblyCompanyAttribute;

        // Did we fail?
        if (attr == null || attr.Company.Length == 0)
            return string.Empty;

        // Return the text for the attribute.
        return attr.Company;
    }

    // *******************************************************************

    /// <summary>
    /// Reads the value of the <see cref="AssemblyCopyrightAttribute"/> 
    /// attribute for the given assembly.
    /// </summary>
    /// <param name="assembly">The assembly to read from.</param>
    /// <returns>The value of the given assembly's copyright attribute.</returns>
    public static string ReadCopyright(this Assembly assembly)
    {
        // Attempt to read the assembly's copyright attribute.
        object[] attributes = assembly.GetCustomAttributes(
            typeof(AssemblyCopyrightAttribute),
            true
            );

        // Did we fail?
        if (attributes.Length == 0)
            return string.Empty;

        // Attempt to recover a reference to the attribute.
        var attr = attributes[0] as AssemblyCopyrightAttribute;

        // Did we fail?
        if (attr == null || attr.Copyright.Length == 0)
            return string.Empty;

        // Return the text for the attribute.
        return attr.Copyright;
    }

    // *******************************************************************

    /// <summary>
    /// Reads the value of the <see cref="AssemblyTitleAttribute"/>
    /// attribute for the given assembly.
    /// </summary>
    /// <param name="assembly">The assembly to read from.</param>
    /// <returns>The value of the given assembly's title attribute.</returns>
    public static string ReadTitle(this Assembly assembly)
    {
        // Attempt to read the assembly's title attribute.
        object[] attributes = assembly.GetCustomAttributes(
            typeof(AssemblyTitleAttribute),
            true
            );

        // Did we fail?
        if (attributes.Length == 0)
            return string.Empty;

        // Attempt to recover a reference to the attribute.
        var attr = attributes[0] as AssemblyTitleAttribute;

        // Did we fail?
        if (attr == null || attr.Title.Length == 0)
            return string.Empty;

        // Return the text for the attribute.
        return attr.Title;
    }

    // ******************************************************************

    /// <summary>
    /// Reads the value of the <see cref="AssemblyDescriptionAttribute"/>
    /// attribute for the given assembly.
    /// </summary>
    /// <param name="assembly">The assembly to read from.</param>
    /// <returns>The value of the given assembly's description attribute.</returns>
    public static string ReadDescription(this Assembly assembly)
    {
        // Attempt to read the assembly's description attribute.
        object[] attributes = assembly.GetCustomAttributes(
            typeof(AssemblyDescriptionAttribute),
            true
            );

        // Did we fail?
        if (attributes.Length == 0)
            return string.Empty;

        // Attempt to recover a reference to the attribute.
        var attr = attributes[0] as AssemblyDescriptionAttribute;

        // Did we fail?
        if (attr == null || attr.Description.Length == 0)
            return string.Empty;

        // Return the text for the attribute.
        return attr.Description;
    }

    // ******************************************************************

    /// <summary>
    /// Reads the value of the <see cref="AssemblyProductAttribute"/>
    /// attribute for the given assembly.
    /// </summary>
    /// <param name="assembly">The assembly to read from.</param>
    /// <returns>The value of the given assembly's product attribute.</returns>
    public static string ReadProduct(this Assembly assembly)
    {
        // Attempt to read the assembly's product attribute.
        object[] attributes = assembly.GetCustomAttributes(
            typeof(AssemblyProductAttribute),
            true
            );

        // Did we fail?
        if (attributes.Length == 0)
            return string.Empty;

        // Attempt to recover a reference to the attribute.
        var attr = attributes[0] as AssemblyProductAttribute;

        // Did we fail?
        if (attr == null || attr.Product.Length == 0)
            return string.Empty;

        // Return the text for the attribute.
        return attr.Product;
    }

    // ******************************************************************

    /// <summary>
    /// Reads the value of the <see cref="AssemblyTrademarkAttribute"/>
    /// attribute for the given assembly.
    /// </summary>
    /// <param name="assembly">The assembly to read from.</param>
    /// <returns>The value of the given assembly's trademark attribute.</returns>
    public static string ReadTrademark(this Assembly assembly)
    {
        // Attempt to read the assembly's trademark attribute.
        object[] attributes = assembly.GetCustomAttributes(
            typeof(AssemblyTrademarkAttribute),
            true
            );

        // Did we fail?
        if (attributes.Length == 0)
            return string.Empty;

        // Attempt to recover a reference to the attribute.
        var attr = attributes[0] as AssemblyTrademarkAttribute;

        // Did we fail?
        if (attr == null || attr.Trademark.Length == 0)
            return string.Empty;

        // Return the text for the attribute.
        return attr.Trademark;
    }

    // ******************************************************************

    /// <summary>
    /// Reads the value of the <see cref="AssemblyVersionAttribute"/>
    /// attribute for the given assembly.
    /// </summary>
    /// <param name="assembly">The assembly to read from.</param>
    /// <returns>The value of the given assembly's version attribute.</returns>
    public static string ReadAssemblyVersion(this Assembly assembly)
    {
        // Attempt to read the assembly's version attribute.
        object[] attributes = assembly.GetCustomAttributes(
            typeof(AssemblyVersionAttribute),
            true
            );

        // Did we fail?
        if (attributes.Length == 0)
            return string.Empty;

        // Attempt to recover a reference to the attribute.
        var attr = attributes[0] as AssemblyVersionAttribute;

        // Did we fail?
        if (attr == null || attr.Version.Length == 0)
            return string.Empty;

        // Return the text for the attribute.
        return attr.Version;
    }

    // ******************************************************************

    /// <summary>
    /// Reads the value of the <see cref="AssemblyInformationalVersionAttribute"/>
    /// attribute for the given assembly.
    /// </summary>
    /// <param name="assembly">The assembly to read from.</param>
    /// <returns>The value of the given assembly's informational version attribute.</returns>
    public static string ReadInformationalVersion(this Assembly assembly)
    {
        // Attempt to read the assembly's version attribute.
        object[] attributes = assembly.GetCustomAttributes(
            typeof(AssemblyInformationalVersionAttribute),
            true
            );

        // Did we fail?
        if (attributes.Length == 0)
            return string.Empty;

        // Attempt to recover a reference to the attribute.
        var attr = attributes[0] as AssemblyInformationalVersionAttribute;

        // Did we fail?
        if (attr == null || attr.InformationalVersion.Length == 0)
            return string.Empty;

        // Look for a '+' character, which, if found, signifies the start
        //   of semver 2.0 version info and should be removed.
        var index = attr.InformationalVersion.IndexOf('+');

        // Did we find it?
        if (0 < index)
        {
            // Strip off everythign past the '+' character.
            return attr.InformationalVersion.Substring(
                0,
                attr.InformationalVersion.Length - index - 2
                );
        }
        else
        {
            // Return the text for the attribute.
            return attr.InformationalVersion;
        }
    }

    // ******************************************************************

    /// <summary>
    /// Reads the value of the <see cref="GuidAttribute"/> attribute 
    /// attribute for the given assembly.
    /// </summary>
    /// <param name="assembly">The assembly to read from.</param>
    /// <returns>The value of the given assembly's guid attribute.</returns>
    public static string ReadGuid(this Assembly assembly)
    {
        // Attempt to read the assembly's guid attribute.
        object[] attributes = assembly.GetCustomAttributes(
            typeof(GuidAttribute),
            true
            );

        // Did we fail?
        if (attributes.Length == 0)
            return string.Empty;

        // Attempt to recover a reference to the attribute.
        var attr = attributes[0] as GuidAttribute;

        // Did we fail?
        if (attr == null || attr.Value.Length == 0)
            return string.Empty;

        // Return the text for the attribute.
        return attr.Value;
    }

    #endregion
}
