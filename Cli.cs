using Basic.Util;

namespace Basic;
public class Cli
{
    public static async Task Interpreter()
    {
        Log.Out("");
        while (true)
        {
            try
            {
                Log.Alert("\nPlease enter a command or 'help'. Commands are not case sensitive");
                var command = Console.ReadLine().Trim();
                var commandArr = SplitArgs(command);
                var verb = commandArr[0].ToLower();
                if (!string.IsNullOrEmpty(verb))
                {
                    var cmd = Command.commands
                        .Where(p => p.Key.Equals(verb, StringComparison.CurrentCultureIgnoreCase))
                        .Select(p => p.Value.Command)
                        .Single();
                    await cmd(commandArr);
                }
            }
            catch (Exception)
            {
                Log.Error("Invalid command. Please type 'help' for more information.");
            }
        }
    }
    private static string[] SplitArgs(string arg)
    {
        var quotecount = arg.Count(x => x == '"');
        if (quotecount % 2 != 0)
        {
            Log.Alert("Your command contains an uneven number of quotes. Was that intended?");
        }
        var segments = arg.Split('"', StringSplitOptions.RemoveEmptyEntries);
        var elements = new List<string>();
        for (var i = 0; i < segments.Length; i++)
        {
            if (i % 2 == 0)
            {
                var parts = segments[i].Split(Array.Empty<char>(), StringSplitOptions.RemoveEmptyEntries);
                elements.AddRange(parts.Select(ps => ps.Trim()));
            }
            else
            {
                elements.Add(segments[i].Trim());
            }
        }
        return [.. elements]; // fancy way of writing `return elements.ToString();`
    }
}
