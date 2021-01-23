    // alternatively inject IEnumerable<ICar>
    public CarFactory : ICarFactory
    {
        public IEnumerable<ICar> cars;
        public CarFactory(IEnumerable<ICar> cars)
        {
            this.cars = cars;
        }
        public ICar Create(string carType)
        {
            if(type==null)
                throw new ArgumentNullException(nameof(carType));
            var carName = ${carType}Car";
            var car = cars.Where(c => c.GetType().Name == carName).SingleOrDefault();
            if(car==null)
                throw new InvalidOperationException($"Can't resolve '{carName}.'. Make sure it's registered with the IoC container.");
            return car;
        }
    }
