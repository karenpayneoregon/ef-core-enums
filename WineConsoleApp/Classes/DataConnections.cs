namespace WineConsoleApp.Classes;
#nullable disable

/// <summary>
/// Represents a singleton class that manages data connection configurations for the application.
/// </summary>
public sealed class DataConnections
{
    private static readonly Lazy<DataConnections> Lazy = new(() => new DataConnections());
    public static DataConnections Instance => Lazy.Value;

    /// <summary>
    /// Gets or sets the primary data connection string used by the application.
    /// </summary>
    public string Main { get; set; }
}