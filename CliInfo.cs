namespace Basic;
public struct CliInfo
{
    public string HelpText { get; set; }
    public Func<string[], Task> Command { get; set; }
}
