#pragma warning disable CS8618
namespace BooksLibrary.Models;

public class BookConnect
{
    public BookConnectId BookConnectId { get; set; }
    public string Name { get; set; }
    public List<Book> Books { get; set; }
    public override string ToString() => Name;
}