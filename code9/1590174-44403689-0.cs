    public class Engine
    {
        public int Code { get; set; }
        public DateTime Year { get; set; }
    }
    public class Car
    {    
        public string Brand { get; set; }
        public string Model { get; set; }
        public Engine Engine {get; set; } 
    }
