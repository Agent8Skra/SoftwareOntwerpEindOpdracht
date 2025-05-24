using WeerEventsApi.Steden;
using WeerEventsApi.Weerstations.Metingen.Enums;

namespace WeerEventsApi.Weerstations.Metingen
{
    public class Meting
    {
        public DateTime Moment { get; set; }
        public double Waarde { get; set; }
        public Eenheid Eenheid { get; set; }
        public Stad Locatie { get; set; }
    }
}
