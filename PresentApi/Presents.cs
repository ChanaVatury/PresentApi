namespace PresentApi
{
    public class Presents
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public double TicketPrice { get; set; }
        public string Donar { get; set; }
        public string Image { get; set; }
        public int? Quantity { get; set; } = 1;
    }
}
