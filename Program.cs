using System.Runtime.InteropServices;
using Basic;
using Basic.Util;

internal class Program
{
    private static async Task Main(string[] args)
    {
        SetWindowSize();
        Log.Ok("Welcome to basic CLI applciation");
        await Cli.Interpreter();
    }

    static void SetWindowSize()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            var width = Math.Min(Console.LargestWindowWidth, 150);
            var height = Math.Min(Console.LargestWindowHeight, 40);
            Console.SetWindowSize(width, height);
        }
    }
}