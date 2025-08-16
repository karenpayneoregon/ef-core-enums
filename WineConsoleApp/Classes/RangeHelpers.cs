using System.Reflection;
using WineConsoleApp.Models;

namespace WineConsoleApp.Classes;

public class RangeHelpers
{
    /// <summary>
    /// Converts a list of elements into a list of containers, each containing the element and its associated indexing information.
    /// </summary>
    /// <typeparam name="T">The type of elements in the input list.</typeparam>
    /// <param name="list">The list of elements to process.</param>
    /// <returns>
    /// A list of <see cref="Container{T}"/> objects, where each container includes the element, its start index, end index, and ordinal index.
    /// </returns>
    public static List<Container<T>> Get<T>(List<T> list)
    {
        var elementsList = list.Select((element, index) => new Container<T>
        {
            Value = element,
            StartIndex = new Index(index),
            EndIndex = new Index(list.Count - index - 1, true),
            OrdinalIndex = index + 1
        }).ToList();

        return elementsList;
    }
}