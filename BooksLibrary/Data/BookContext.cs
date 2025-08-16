using BooksLibrary.Models;
using ConsoleConfigurationLibrary.Classes;
using Microsoft.EntityFrameworkCore;
#pragma warning disable CS8618

namespace BooksLibrary.Data;

public class BookContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<BookConnect> BookConnect { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(AppConnections.Instance.MainConnection);
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