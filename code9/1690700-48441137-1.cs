    class Motorcycle : Vehicle { }
    class Program
    {
        static void Main()
        {
            var factory = new VehicleFactory();
            factory.RegisterConstructor("motorcycle", () => new Motorcycle());
            var bike = factory.Create("motorcycle");
            var car  = factory.Create("car");
        }
    }
