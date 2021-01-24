    public class Batter
    {
        public string id { get; set; }
        public string type { get; set; }
    }
    
    public class Batters
    {
        public List<Batter> batter { get; set; }
    }
    
    public class Topping
    {
        public string id { get; set; }
        public string type { get; set; }
    }
    
    public class RootObject
    {
        public string id { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public double ppu { get; set; }
        public Batters batters { get; set; }
        public List<Topping> topping { get; set; }
    }
