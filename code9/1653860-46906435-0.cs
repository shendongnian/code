    public class WaardePaar
    {
        public string Naam { get; set; }
        public string Waarde { get; set; }
    }
    public WaardeObjecten(IEnumerable<WaardePaar> paren)
    {
        // store in a private field list or array
        _values = paren.ToList();
    }
