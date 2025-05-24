namespace WeerEventsApi.Weerberichten
{
    public class Weerbericht
    {
        public DateTime CreatedAt { get; set; }
        public required string Content { get; set; }
    }
}
