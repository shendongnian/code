    public class Rates
    {
        public double ABC { get; set; }
        public double DEF { get; set; }
        public int GHI { get; set; }
        public bool ShouldSerializeGHI()
        {
            if (this.GHI == 0)
                return false;
            return true;
        }
    }
    public class RootObject
    {
        public string Date { get; set; }
        public string Location { get; set; }
        public Rates rates { get; set; }
    }
