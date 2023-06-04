namespace admLab1.Models
{
    public class NvidiaGraphicsCardsGF
    {
        public Guid Id { get; set; } = Guid.Empty;
        public string Series { get; set; }
        public string Memory { get; set; }
        public int Bits { get; set; }
        public int Price { get; set; }
    }
}
