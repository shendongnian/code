    public class CarRepository
    {
        private readonly SqlCarStore _carStore;
        public CarRepository(SqlCarStore carStore)
        {
            _carStore = carStore;
        }
        public IEnumerable<Car> GetCars()
        {
            IEnumerable<CarEntity> dbCars = _carStore.GetCars();
            return dbCars.Select(c => c.ToCar());
        }
    }
    public static class CarEntityExtensions
    {
        //Maps from CarEntity to Car
        public static Car ToCar(this CarEntity entityCar)
        {
            return new Car
            {
                Make = entityCar.Make,
                Model = entityCar.Model,
                Year = entityCar.Year,
                HorsePower = entityCar.HorsePower.ToString(),
            };
        }
    }
    public class CarEntity
    {
        public string Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public int HorsePower { get; set; }
    }
    public class Car
    {
        private string _horsePower;
        public string Make { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public string HorsePower
        {
            get { return _horsePower; }
            set { _horsePower = $"{value} horses"; }
        }
    }
