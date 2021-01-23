    public ICarFactory
    {
        ICar Create(string carType);
    }
    public CarFactory : ICarFactory
    {
        public IServiceProvider provider;
        public CarFactory(IServiceProvider provider)
        {
            this.provider = provider;
        }
        public ICar Create(string carType)
        {
            if(type==null)
                throw new ArgumentNullException(nameof(carType));
            var fullQualifedName = $"MyProject.Business.Models.Cars.{carType}Car";
            Type carType = Type.GetType(fullQualifedName);
            if(carType==null)
                throw new InvalidOperationException($"'{carType}' is not a valid car type.");
            ICar car = provider.GetService(carType);
            if(car==null)
                throw new InvalidOperationException($"Can't resolve '{carType.Fullname}'. Make sure it's registered with the IoC container.");
            return car;
        }
    }
