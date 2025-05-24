using System.Text.Json;

namespace WeerEventsApi.Logging.Decorators
{
    public class JsonLoggerDecorator : IMetingLogger
    {
        private readonly IMetingLogger _inner;

        public JsonLoggerDecorator(IMetingLogger inner)
        {
            _inner = inner;
        }

        public void Log(string message)
        {
            var entry = new
            {
                Moment = DateTime.Now,
                Bericht = message
            };

            string json = JsonSerializer.Serialize(entry);
            File.AppendAllText("log.json", json + Environment.NewLine);

            _inner.Log(message);
        }
    }
}
