
using Basic.Util;

namespace Basic;
public class Command
{
    // need a loader function that can load commands from json files on start
    public static Dictionary<string, CliInfo> commands = new Dictionary<string, CliInfo>
            {
                { "Help", new CliInfo { Command=CommandHelp, HelpText="List all commands" } },
                { "Exit", new CliInfo { Command=CommandExit, HelpText="Exits the program" } },
            };

    private static Task CommandExit(string[]? args = null)
    {
        Environment.Exit(0);
        return Task.CompletedTask;
    }

    private static Task CommandHelp(string[]? args = null)
    {
        Log.Ok("This sample app is a template of a command line application that runs on user defined command ");
        Log.Ok("and issue some defined commands");
        Log.Out("");
        if (args != null && args.Length < 2)
        {
            var clist = commands
                        .Where(p => p.Value.Command != null)
                        .Select(p => new { Cmd = p.Key, Help = p.Value.HelpText });
            foreach (var item in clist)
            {
                Log.Out($"\t{item.Cmd}\t{item.Help}");
            }
        }
        return Task.CompletedTask;
    }
}