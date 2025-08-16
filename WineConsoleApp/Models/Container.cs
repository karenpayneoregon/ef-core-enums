#nullable enable
namespace WineConsoleApp.Models;

/// <summary>
/// Represents a container that holds a value of type <typeparamref name="T"/> along with associated indexing information.
/// </summary>
/// <typeparam name="T">The type of the value contained within the container.</typeparam>
public class Container<T>
{
    public T? Value { get; set; }
    public Index StartIndex { get; set; }
    public int OrdinalIndex { get; set; }
    public Index EndIndex { get; set; }
}