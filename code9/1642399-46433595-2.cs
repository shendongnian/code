    public abstract class VehicleFactory
    {
         public abstract Vehicle GetVehicle(string VehicleType)
    }
    
    public class CarFactory : VehicleFactory
    {
        public override Vehicle GetVehicle(string VehicleType)
        {
              return new Car();
        }
    }
