    public class Vejnavn
    {
        public string href { get; set; }
        public string navn { get; set; } // not List<Vejnavne> vejnavn
    }
    
    public class Address
    {
        public string tekst { get; set; }
        public Vejnavn vejnavn { get; set; }
    }
