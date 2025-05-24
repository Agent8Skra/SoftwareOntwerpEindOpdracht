namespace WeerEventsApi.Logging;

public class MetingLogger : IMetingLogger
{
    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}