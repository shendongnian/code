    public class VehicleServiceFactory
    {
        public IVehicleService GetVehicleService(Vehicle vehicle)
        {
            var attributes = vehicle.GetType().GetCustomAttributes(typeof(ServiceAttribute), false);
            if (attributes.Length == 0)
                throw new NotSupportedException("Vehicle not supported");
            return (IVehicleService) Activator.CreateInstance(((ServiceAttribute)attributes[0]).Service);
        }
    }
