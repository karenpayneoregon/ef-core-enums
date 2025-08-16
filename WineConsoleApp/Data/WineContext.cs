﻿using ConsoleConfigurationLibrary.Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WineConsoleApp.Models;

#pragma warning disable CS8618

namespace WineConsoleApp.Data;

public class WineContext : DbContext
{
    public DbSet<Wine> Wines { get; set; }
    public DbSet<WineTypes> WineTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(AppConnections.Instance.MainConnection)
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Wine>()
            .Property(e => e.WineType)
            .HasConversion<int>();

        if (!EntitySettings.Instance.CreateNew)
            return;

        modelBuilder.Entity<WineTypes>().HasData(
            new WineTypes() {Id = 1, TypeName = "Red", Description = "Classic red"},
            new WineTypes() {Id = 2, TypeName = "White", Description = "Dinner white"},
            new WineTypes() {Id = 3, TypeName = "Rose", Description = "Imported rose"}
        );

        modelBuilder.Entity<Wine>().HasData(
            new Wine() { WineId = 1, Name = "Veuve Clicquot Rose", WineType = WineType.Red },
            new Wine() { WineId = 2, Name = "Whispering Angel Rose", WineType = WineType.Rose },
            new Wine() { WineId = 3, Name = "Pinot Grigi", WineType = WineType.White },
            new Wine() { WineId = 4, Name = "White Zinfandel", WineType = WineType.Rose }
        );
    }
}