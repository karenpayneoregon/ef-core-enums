namespace WineConsoleApp.Models;

/// <summary>
/// Represents a grouped item of wines categorized by a specific wine type.
/// </summary>
/// <remarks>
/// This class is used to group wines by their type, encapsulating the wine type as the key 
/// and a list of wines belonging to that type. It is particularly useful for operations 
/// that involve grouping and displaying wines based on their type.
/// </remarks>
public class WineGroupItem(WineType key, List<Wine> list)
{
    public WineType Key { get; } = key;
    public List<Wine> List { get; } = list;
}