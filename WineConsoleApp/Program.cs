using ConsoleConfigurationLibrary.Classes;
using WineConsoleApp.Classes;
using WineConsoleApp.Data;

namespace WineConsoleApp;

internal partial class Program
{
    static void Main(string[] args)
    {
        using var context = new WineContext();

        if (EntitySettings.Instance.CreateNew)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }

        WineOperations.Run();

        Line();

        WineOperations.Indexing();

        ExitPrompt();
    }
}