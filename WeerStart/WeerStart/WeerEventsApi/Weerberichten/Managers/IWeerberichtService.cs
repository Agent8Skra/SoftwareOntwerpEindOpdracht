
using System.Collections.Generic;
using WeerEventsApi.Weerstations.Metingen;
using WeerEventsApi.Weerberichten.Managers;


namespace WeerEventsApi.Weerberichten.Managers
{
    public interface IWeerberichtService
    {
        Weerbericht GenerateReport(List<Meting> metingen);
    }
}
