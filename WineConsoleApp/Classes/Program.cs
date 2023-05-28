using System.Runtime.CompilerServices;

namespace WineConsoleApp.Classes;
internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        Console.Title = "Code sample";
    }
}
