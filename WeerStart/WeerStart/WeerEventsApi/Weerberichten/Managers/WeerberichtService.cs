using WeerEventsApi.Weerstations.Metingen;

namespace WeerEventsApi.Weerberichten.Managers
{
    public class WeerberichtService : IWeerberichtService
    {
        public Weerbericht GenerateReport(List<Meting> metingen)
        {
            Thread.Sleep(5000);

            string inhoud = $"Op basis van {metingen.Count} metingen en mijn ziepzinnig computermodel kan ik zeggen dat er kans is op ";
            inhoud += metingen.Count % 2 == 0 ? "goed weer." : "slecht weer.";

            return new Weerbericht
            {
                CreatedAt = DateTime.Now,
                Content = inhoud
            };
        }
    }
}
