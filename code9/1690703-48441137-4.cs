    public sealed class VehicleFactory
    {
        public VehicleFactory(params (string name, Func<Vehicle> constructor)[] constructors)
        {
            _map.Add("car", () => new Car());
            _map.Add("bus", () => new Bus());
            foreach (var c in constructors)
            {
                _map.Add(c.name, c.constructor);
            }
        }
        public Vehicle Create(string name)
        {
            if (_map.TryGetValue(name, out Func<Vehicle> create))
                return create();
            throw new InvalidOperationException($"No such vehicle name: {name}");
        }
        readonly Dictionary<string, Func<Vehicle>> _map = new Dictionary<string, Func<Vehicle>>();
    }
