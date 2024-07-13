using System.Text;
using System.Linq;

namespace Basic.Applog;
public class AppLog
{
    private DateTimeOffset now;
    private string[]? arg;

    public AppLog()
    {
    }

    public AppLog(DateTimeOffset now, string[]? arg)
    {
        this.TimeStamp = now;
        this.Activity = string.Join(' ', arg);
    }

    public DateTimeOffset TimeStamp { get; set; }
    public string Activity { get; set; }

    private static string filename;

    public static void Init()
    {
        filename = DateTimeOffset.Now.ToString("yyyyMMddHHmmssfff");
        if (!Directory.Exists("logs"))
        {
            // Create the directory
            Directory.CreateDirectory("logs");
        }
    }
    public static void WriteOut(AppLog log)
    {
        var sb = new StringBuilder();
        sb.Append(log.TimeStamp.ToString());
        sb.Append('\t');
        sb.Append(log.Activity);
        const int BufferSize = 65536;  // 64 Kilobytes
        using var sw = new StreamWriter($"logs/{filename}.log", true, Encoding.UTF8, BufferSize);
        sw.WriteLine(sb.ToString());
        sb.Clear();
    }
}
