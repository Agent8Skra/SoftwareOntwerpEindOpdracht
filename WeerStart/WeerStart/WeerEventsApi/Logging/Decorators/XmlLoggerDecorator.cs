namespace WeerEventsApi.Logging.Decorators
{
    public class XmlLoggerDecorator : IMetingLogger
    {
        private readonly IMetingLogger _inner;

        public XmlLoggerDecorator(IMetingLogger inner)
        {
            _inner = inner;
        }

        public void Log(string message)
        {
            string xml = $"<Meting>\n\t<Moment>{DateTime.Now}</Moment>\n\t<Bericht>{System.Security.SecurityElement.Escape(message)}</Bericht>\n</Meting>\n";
            File.AppendAllText("log.xml", xml);

            _inner.Log(message);
        }
    }
}
