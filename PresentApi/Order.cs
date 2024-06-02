namespace PresentApi
{
    public class Order
    {
        public int Id { get; set; }
        public int UserNumber { get; set; }
        public string Email { get; set; }
        public int Total { get; set; }
        public List<Presents> Tickets { get; set; } = new List<Presents>();
    }
}
