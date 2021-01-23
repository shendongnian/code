    public abstract class Vehicle : IVehicle
    {
        public int Wheels { get; protected set; }
        public Vehicle()
        {
            Wheels = 4;
        }
        public int CountWheels()
        {
            return Wheels;
        }
    }
    public class Motorcycle : Vehicle, IVehicle
    {
        public Motorcycle()
        {
            Wheels = 2;
        }
    }
