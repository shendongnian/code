        public static void Main(string[] args)
        {
            var factory = new VehicleServiceFactory();
            Vehicle vehicle = GetVehicle();
            var vehicleService = factory.GetVehicleService(vehicle);
            vehicleService.ServiceVehicle();
            Console.ReadLine();
        }
        public static Vehicle GetVehicle()
        {
            return new Truck() {Id=1};
            //return new Car() { Id = 2 }; ;
        }
        public interface IVehicleService
        {
            void ServiceVehicle();
        }
        public class CarService : IVehicleService
        {
            private readonly Car _car;
            public CarService(Car car)
            {
                _car = car;
            }
            public void ServiceVehicle()
            {
                Console.WriteLine($"Service Car {_car.Id}");
            }
        }
        public class TruckService : IVehicleService
        {
            private readonly Truck _truck;
            public TruckService(Truck truck)
            {
                _truck = truck;
            }
            public void ServiceVehicle()
            {
                Console.WriteLine($"Service Truck {_truck.Id}");
            }
        }
        public class VehicleServiceFactory
        {
            public IVehicleService GetVehicleService(Vehicle vehicle)
            {
                if (vehicle is Car)
                {
                    return new CarService((Car)vehicle);
                }
                if (vehicle is Truck)
                {
                    return new TruckService((Truck)vehicle);
                }
                throw new NotSupportedException("Vehicle not supported");
            }
        }
        public abstract class Vehicle
        {
            public int Id;
        }
        public class Car : Vehicle
        {
        }
        public class Truck : Vehicle
        {
        }
