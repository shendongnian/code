    public class House
    {
        public decimal Height { get; set; }
        public House AddFloor()
        {
            Height += 100;
            return this;
        }
    }
