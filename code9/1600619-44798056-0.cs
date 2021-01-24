    public class Car
    {
        public string color { get; set; }
        public int miles { get; set; }
        public string vin { get; set; }
    }
    
    public class Truck
    {
        public string color { get; set; }
        public int miles { get; set; }
        public string vin { get; set; }
    }
    
    public class RootObject
    {
        public List<Car> Cars { get; set; }
        public Truck truck { get; set; }
    }
