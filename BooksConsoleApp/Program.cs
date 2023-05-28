using BooksLibrary.Classes;
using BooksLibrary.Models;
using Spectre.Console;

namespace BooksConsoleApp;

partial class Program
{
    static void Main(string[] args)
    {
        
        var bookList = BookOperations.AddViewBooks(true);

        var allBooksTable = new Table()
            .RoundedBorder()
            .AddColumn("[b]Id[/]")
            .AddColumn("[b]Title[/]")
            .AddColumn("[b]Category[/]")
            .Alignment(Justify.Center)
            .BorderColor(Color.LightSlateGrey)
            .Title("[yellow]All books[/]");

        foreach (var book in bookList)
        {
            allBooksTable.AddRow(
                book.BookId.ToString(),
                book.Title,
                book.BookConnectId.ToString()
            );
        }

        AnsiConsole.Write(allBooksTable);

        var programmingTable = new Table()
            .RoundedBorder()
            .AddColumn("[b]Id[/]")
            .AddColumn("[b]Title[/]")
            .AddColumn("[b]Category[/]")
            .Alignment(Justify.Center)
            .BorderColor(Color.LightSlateGrey)
            .Title("[yellow]Programming books[/]");


        var programmingBooks = bookList
            .Where(books => books.BookConnectId == BookConnectId.Programming)
            .ToList();

        
        foreach (var book in programmingBooks)
        {

            programmingTable.AddRow(
                book.BookId.ToString(),
                book.Title,
                book.BookConnectId.ToString());

        }

        AnsiConsole.Write(programmingTable);

        var automotiveBooks = bookList.Where(books => books.BookConnectId == BookConnectId.Automobile).ToList();
        var automotiveTable = new Table()
            .RoundedBorder()
            .AddColumn("[b]Id[/]")
            .AddColumn("[b]Title[/]")
            .AddColumn("[b]Category[/]")
            .Alignment(Justify.Center)
            .BorderColor(Color.LightSlateGrey)
            .Title("[yellow]Automotive books[/]");

        
        foreach (var book in automotiveBooks)
        {

            automotiveTable.AddRow(
                book.BookId.ToString(),
                book.Title,
                book.BookConnectId.ToString());

        }

        AnsiConsole.Write(automotiveTable);

        ExitPrompt();

    }
}