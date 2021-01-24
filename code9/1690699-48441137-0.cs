    public sealed class VehicleFactory
    {
        public VehicleFactory()
        {
            RegisterConstructor("car", () => new Car());
            RegisterConstructor("bus", () => new Bus());
        }
        public void RegisterConstructor(string name, Func<Vehicle> func)
        {
            _map.Add(name, func);
        }
        public Vehicle Create(string name)
        {
            if (_map.TryGetValue(name, out Func<Vehicle> create))
                return create();
            throw new InvalidOperationException($"No such vehicle name: {name}");
        }
        readonly Dictionary<string, Func<Vehicle>> _map = new Dictionary<string, Func<Vehicle>>();
    }
