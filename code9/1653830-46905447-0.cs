    public class House
    {
        public decimal Height { get; set; }
        public bool IsItTooBig()
        {
            return this.Height > 200;
        }
    }
