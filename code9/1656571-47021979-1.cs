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
