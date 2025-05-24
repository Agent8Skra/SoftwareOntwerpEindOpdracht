using WeerEventsApi.Weerberichten.Managers;
using WeerEventsApi.Weerstations.Metingen;

namespace WeerEventsApi.Weerberichten.Proxies
{
    public class WeerberichtProxy : IWeerberichtService
    {
        private readonly IWeerberichtService _realService;
        private Weerbericht? _cached;
        private DateTime _lastGenerated;

        public WeerberichtProxy(IWeerberichtService realService)
        {
            _realService = realService;
            _lastGenerated = DateTime.MinValue;
        }

        public Weerbericht GenerateReport(List<Meting> metingen)
        {
            if (_cached == null || (DateTime.Now - _lastGenerated).TotalSeconds > 60)
            {
                _cached = _realService.GenerateReport(metingen);
                _lastGenerated = DateTime.Now;
            }

            return _cached;
        }
    }
}
