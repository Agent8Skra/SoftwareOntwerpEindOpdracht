using WeerEventsApi.Steden;
using WeerEventsApi.Weerstations.Metingen;
using WeerEventsApi.Weerstations.Metingen.Enums;

namespace WeerEventsApi.Weerstations
{
    public class Weerstation
    {
        public string Type { get; set; } // "Wind", "Neerslag", "Temperatuur", "Luchtdruk"
        public Stad Locatie { get; set; }
        public List<Meting> Metingen { get; set; } = new();

        public Meting DoeMeting()
        {
            var rng = new Random();
            double waarde = Type switch
            {
                "Wind" => rng.Next(0, 150),
                "Neerslag" => rng.Next(0, 100),
                "Temperatuur" => rng.Next(-20, 40),
                "Luchtdruk" => rng.Next(950, 1050),
                _ => 0
            };

            var eenheid = Type switch
            {
                "Wind" => Eenheid.KilometerPerUur,
                "Neerslag" => Eenheid.MillimeterPerVierkanteMeterPerUur,
                "Temperatuur" => Eenheid.GradenCelsius,
                "Luchtdruk" => Eenheid.HectoPascal,
                _ => Eenheid.GradenCelsius
            };

            var meting = new Meting
            {
                Moment = DateTime.Now,
                Waarde = waarde,
                Eenheid = eenheid,
                Locatie = Locatie
            };

            Metingen.Add(meting);
            return meting;
        }
    }
}
