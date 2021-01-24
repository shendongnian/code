    class Program
    {
        private static CompositionContainer _container;
        public Program()
        {
            var aggList = AppDomain.CurrentDomain
                                   .GetAssemblies()
                                   .Select(asm => new AssemblyCatalog(asm))
                                   .Cast<ComposablePartCatalog>()
                                   .ToArray();
            var catalog = new AggregateCatalog(aggList);
            _container = new CompositionContainer(catalog);
            _container.ComposeParts(this);
        }
        static void Main(string[] args)
        {
            var prg = new Program();
            var car = _container.GetExportedValue<IVehicle>("CAR") as Car; 
            var carService = _container.GetExportedValue<IVehicleService<Car>>("CARSERVICE") as CarService;
            carService.ServiceVehicle(car);
            var truck = _container.GetExportedValue<IVehicle>("TRUCK") as Truck;
            var truckService = _container.GetExportedValue<IVehicleService<Truck>>("TRUCKSERVICE") as TruckService;
            truckService.ServiceVehicle(truck);
            Console.ReadLine();
        }
    }
    public interface IVehicleService<in T> 
    {
        void ServiceVehicle(T vehicle);
    }
    public interface IVehicle
    {
    }
    [Export("CARSERVICE", typeof(IVehicleService<Car>)), PartCreationPolicy(System.ComponentModel.Composition.CreationPolicy.NonShared)]
    public class CarService : IVehicleService<Car>
    {
        public void ServiceVehicle(Car vehicle)
        {
        }
    }
    [Export("TRUCKSERVICE", typeof(IVehicleService<Truck>)), PartCreationPolicy(System.ComponentModel.Composition.CreationPolicy.NonShared)]
    public class TruckService : IVehicleService<Truck>
    {
        public void ServiceVehicle(Truck vehicle)
        {
            
        }
    }
    public abstract class Vehicle : IVehicle
    {
    }
    [Export("CAR", typeof(IVehicle)), PartCreationPolicy(System.ComponentModel.Composition.CreationPolicy.NonShared)]
    public class Car : Vehicle
    {
    }
    [Export("TRUCK", typeof(IVehicle)), PartCreationPolicy(System.ComponentModel.Composition.CreationPolicy.NonShared)]
    public class Truck : Vehicle
    {
    }
