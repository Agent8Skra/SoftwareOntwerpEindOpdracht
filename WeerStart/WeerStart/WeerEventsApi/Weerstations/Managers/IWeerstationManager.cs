using WeerEventsApi.Weerstations;
using WeerEventsApi.Weerstations.Metingen;

namespace WeerEventsApi.Weerstations.Managers
{
    public interface IWeerstationManager
    {
        List<Weerstation> GetStations();
        void DoeMetingen();
        List<Meting> GetMetingen();
    }
}
