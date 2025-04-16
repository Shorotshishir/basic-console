using System.Diagnostics;

namespace Basic.Util;
public class Timer
{
    private static Stopwatch stopwatch;

    public static void Start()
    {
        stopwatch = new Stopwatch();
        stopwatch.Start();
    }

    public static long Stop()
    {
        stopwatch.Stop();
        return stopwatch.ElapsedMilliseconds;
    }
}
