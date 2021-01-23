    public class NewVehicleViewModel
    {
        public string Type { get; set; }
        public VehicleViewModel Vehicle { get; set; }
    }
    public interface VehicleViewModel
    {
        string Name { get; set; }
        string Color { get; set; }
    }
    public class CarViewModel : VehicleViewModel
    {
        public string Color { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
    }
    public class TankViewModel : VehicleViewModel
    {
        public string Color { get; set; }
        public string Name { get; set; }
        public string Weapon { get; set; }
    }
