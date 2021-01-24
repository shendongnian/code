    public class CarRepository : IVehicleRepository<Car>
    {
        private static ConcurrentDictionary<string, Car> _cars =
              new ConcurrentDictionary<string, Car>();
        public CarRepository()
        {
            Add(new Car { seats = 5 });
        }
        public IEnumerable<Car> GetAll()
        {
            return _cars.Values;
        }
    }
