    public enum WheelType
    {
        TwoWeeled,
        FourWeeled
    }
    public class Vehicle
    {
    }
    public class WheeledVehicle : Vehicle
    {
        public WheelType WheelType { get; set; }
    }
