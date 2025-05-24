using WeerEventsApi.Steden.Managers;
using WeerEventsApi.Weerstations.Metingen;

namespace WeerEventsApi.Weerstations.Managers
{
    public class WeerstationManager : IWeerstationManager
    {
        private readonly List<Weerstation> _stations;

        public WeerstationManager(IStadManager stadManager)
        {
            var types = new[] { "Wind", "Neerslag", "Temperatuur", "Luchtdruk" };
            var steden = stadManager.GeefSteden().ToList();
            var rng = new Random();
            _stations = new();

            for (int i = 0; i < 12; i++)
            {
                _stations.Add(new Weerstation
                {
                    Type = types[rng.Next(types.Length)],
                    Locatie = steden[rng.Next(steden.Count)]
                });
            }
        }

        public List<Weerstation> GetStations() => _stations;

        public void DoeMetingen()
        {
            foreach (var station in _stations)
            {
                station.DoeMeting();
            }
        }

        public List<Meting> GetMetingen() => _stations.SelectMany(s => s.Metingen).ToList();
    }
}
