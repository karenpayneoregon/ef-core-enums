using BooksLibrary.Models;
using Microsoft.EntityFrameworkCore;
#pragma warning disable CS8618

namespace BooksLibrary.Data;

public class BookContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<BookConnect> BookConnect { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            """
                          Server=(localdb)\mssqllocaldb;Database=BookLibrary;
                          Trusted_Connection=True
                          """);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Book>()
            .Property(e => e.BookConnectId)
            .HasConversion<int>();

        modelBuilder
            .Entity<BookConnect>()
            .Property(e => e.BookConnectId)
            .HasConversion<int>();

        modelBuilder
            .Entity<BookConnect>().HasData(
                Enum.GetValues(typeof(BookConnectId))
                    .Cast<BookConnectId>()
                    .Select(e => new BookConnect()
                    {
                        BookConnectId = e,
                        Name = e.ToString()
                    })
            );
    }
}