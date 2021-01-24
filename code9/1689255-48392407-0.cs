    public class Data
    {
        public List<string> err { get; set; }
        public List<string> msg { get; set; }
        public string state { get; set; }
        public Rec rec { get; set; }
    }
    
    public class Rec
    {
        public string Vin { get; set; }
        public string REG { get; set; }
        public string @int { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public string Color { get; set; }
    }
