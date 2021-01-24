    class Program
    {
    static void Main(string[] args)
        {
            var vstateManager = SingletonFactory.GetSingletoneInstance<VStateManager>();
            var vehicleFactory = SingletonFactory.GetSingletoneInstance<VehicleFactory>();
            Console.ReadKey();
        }
    }
