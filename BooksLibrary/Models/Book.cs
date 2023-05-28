namespace BooksLibrary.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public BookConnectId BookConnectId { get; set; }
        public BookConnect BookConnect { get; set; }
        public override string ToString() => Title;
    }
}
