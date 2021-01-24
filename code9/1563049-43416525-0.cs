    abstract class Vehicle
    {
        public abstract string Description { get; }
    }
    
    class Aeroplane : Vehicle
    {
        public string Notes { get; set; }
        public override string Description => Notes;
    }
    
    class Car : Vehicle
    {
        public string Review { get; set; }
        public override string Description => Review;
    }
    
    class Boat : Vehicle
    {
        public string Notes { get; set; }
        public override string Description => Notes;
    }
