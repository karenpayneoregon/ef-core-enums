using WineConsoleApp.Classes;
using WineConsoleApp.Data;

namespace WineConsoleApp;

internal partial class Program
{
    static void Main(string[] args)
    {
        using var context = new WineContext();

        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
        //WineOperations.Run();
        WineOperations.Indexing();

        Console.WriteLine("Finished");
        Console.ReadLine();
    }
}