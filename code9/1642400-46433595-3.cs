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
    public class BikeFactory : VehicleFactory
    {
        public override Vehicle GetVehicle(string VehicleType)
        {
              return new Bike();
        }
    }
    public class ClientClass
    {
        public void Main()
        {
            //Create Factories
            BikeFactory BikeFactoryObj = new BikeFactory();
            CarFactory CarFactoryObj = new CarFactory();
            //create Vehicles from factories. If wanted they can be casted to the inherited type.
            Vehicle VehicleObj=BikeFactoryObj.GetNewVehicle();
            Bike BikeObj = (Bike)BikeFactoryObj.GetVehicle();
            Car CarObj = (Car)CarFactoryObj.GetVehicle();
            //They are all inherited from Vehicle so can be used in a list of Vehicles
            List<Vehicle> Vehicles=new List<Vehicle>()
            {
                 VehicleObj,
                 BikeObj,
                 CarObj
            }
        }
    }
