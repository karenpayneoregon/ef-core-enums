using BooksLibrary.Data;
using BooksLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksLibrary.Classes;

public class BookOperations
{
    /// <summary>
    /// Adds a predefined list of books to the database and retrieves all books.
    /// </summary>
    /// <param name="createDatabase">
    /// A boolean value indicating whether to create the database and its tables before adding books.
    /// Pass <c>true</c> to create the database and populate it with books for the first time.
    /// Pass <c>false</c> to retrieve the existing list of books without recreating the database.
    /// </param>
    /// <returns>
    /// A list of <see cref="Book"/> objects representing all books in the database.
    /// </returns>
    public static List<Book> AddBooks(bool createDatabase = false)
    {
        using var context = new BookContext();

        if (!createDatabase)
            return context
                .Books
                .Include(item => item.BookConnect)
                .ToList();

        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        context.Books.Add(new Book
        {
            Title = "Sports Illustrated",
            BookConnectId = BookConnectId.Sports
        });

        context.Books.Add(new Book
        {
            Title = "Friday Night Lights",
            BookConnectId = BookConnectId.Sports
        });

        context.Books.Add(new Book
        {
            Title = "The logic of sports betting",
            BookConnectId = BookConnectId.Sports
        });

        context.Books.Add(new Book
        {
            Title = "Git for programmers",
            BookConnectId = BookConnectId.Programming
        });

        context.Books.Add(new Book
        {
            Title = "The self-taught programmer",
            BookConnectId = BookConnectId.Programming
        });

        context.Books.Add(new Book
        {
            Title = "C# Programming",
            BookConnectId = BookConnectId.Programming
        });

        context.Books.Add(new Book
        {
            Title = "Beginning Object-Oriented Programming with C#",
            BookConnectId = BookConnectId.Programming
        });

        context.Books.Add(new Book
        {
            Title = "Entity Framework Core in Action",
            BookConnectId = BookConnectId.Programming
        });


        context.Books.Add(new Book
        {
            Title = "Into the Abyss: An Extraordinary True Story",
            BookConnectId = BookConnectId.Adventure
        });

        context.Books.Add(new Book
        {
            Title = "The Terminal List: A Thriller",
            BookConnectId = BookConnectId.Adventure
        });

        context.Books.Add(new Book
        {
            Title = "Space Travel: Impossible to Reality",
            BookConnectId = BookConnectId.SpaceTravel
        });

        context.Books.Add(new Book
        {
            Title = "Galaxies: Birth and Destiny of Our Universe",
            BookConnectId = BookConnectId.SpaceTravel
        });

        context.Books.Add(new Book
        {
            Title = "100 cars that changed the world",
            BookConnectId = BookConnectId.Automobile
        });

        context.Books.Add(new Book
        {
            Title = "Classic cars",
            BookConnectId = BookConnectId.Automobile
        });

        context.Books.Add(new Book
        {
            Title = "Built for Speed: The World's Fastest Road Cars",
            BookConnectId = BookConnectId.Automobile
        });

        context.SaveChanges();

        return context
            .Books
            .Include(item => item.BookConnect)
            .ToList();

    }
}