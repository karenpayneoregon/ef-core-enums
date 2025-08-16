using ConsoleHelperLibrary.Classes;
using Spectre.Console;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;
using static ConsoleConfigurationLibrary.Classes.ApplicationConfiguration;
using ConsoleConfigurationLibrary.Classes;

// ReSharper disable once CheckNamespace
namespace WineConsoleApp;
internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        Console.Title = "Code sample";
        
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);

        Setup();

        AnsiConsole.Write(
            new FigletText("EF Core Enum conversions")
                .Alignment(Justify.Center)
                .Color(Color.White));
        AnsiConsole.Write(
            new FigletText("Wines")
                .Alignment(Justify.Center)
                .Color(Color.White));
    }

    private static void Setup()
    {
        var services = ConfigureServices();
        using var provider = services.BuildServiceProvider();
        var setup = provider.GetService<SetupServices>();
        setup!.GetConnectionStrings();
        setup.GetEntitySettings();
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
    private static void Line()
    {
        Console.WriteLine();
        Render(new Rule($"[yellow]Indexing[/]").RuleStyle(Style.Parse("silver")).Centered());

    }
}
