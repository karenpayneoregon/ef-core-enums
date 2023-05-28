using ConsoleHelperLibrary.Classes;
using System.Runtime.CompilerServices;
using Spectre.Console;


// ReSharper disable once CheckNamespace
namespace BooksConsoleApp;

partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        Console.Title = "Code sample";
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Fill);
        AnsiConsole.Write(
            new FigletText("EF Core Enum conversions")
                .Alignment(Justify.Center)
                .Color(Color.White));
    }

    private static void Render(Rule rule)
    {
        AnsiConsole.Write(rule);
        AnsiConsole.WriteLine();
    }

    private static void ExitPrompt()
    {
        Console.WriteLine();
        Render(new Rule($"[yellow]Press a key to exit the demo[/]").RuleStyle(Style.Parse("silver")).Centered());
        Console.ReadLine();
    }
}