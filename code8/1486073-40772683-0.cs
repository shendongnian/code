    public abstract class Vehicle : IVehicle
    {
        public abstract int Wheels {get;}
    
        public int CountWheels()
        {
            return Wheels;
        }
    }
    public class Motorcycle : Vehicle, IVehicle
    {
        public int Wheels => 2;
    }
