    public interface IVehicleService
    {
        void ServiceVehicle(Vehicle vehicle);
    }
    public abstract class VehicleService<T> : IVehicleService where T : Vehicle
    {
        public void ServiceVehicle(Vehicle vehicle)
        {
            if (vehicle is T actual)
                ServiceVehicle(actual);
            else
                throw new InvalidEnumArgumentException("Wrong type");
        }
        public abstract void ServiceVehicle(T vehicle);
    }
    public class CarService : VehicleService<Car>
    {
        public override void ServiceVehicle(Car vehicle)
        {
            Console.WriteLine("Service Car");
        }
    }
    public class TruckService : VehicleService<Truck>
    {
        public override void ServiceVehicle(Truck vehicle)
        {
            Console.WriteLine("Service Truck");
        }
    }
    public class VehicleServiceFactory
    {
        public IVehicleService GetVehicleService(Vehicle vehicle)
        {
            if (vehicle is Car)
            {
                return new CarService();
            }
            if (vehicle is Truck)
            {
                return new TruckService();
            }
            throw new NotSupportedException("Vehicle not supported");
        }
    }
