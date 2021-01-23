    internal delegate Vehicle VehicleConstructor(string data, string type);
    public static class Factory {
        private static readonly Dictionary<Type, VehicleConstructor> _factories = new Dictionary<Type, VehicleConstructor>() {
            {typeof(Car), (data, type) => new Car(data)},
            {typeof(Plane), (data, type) => new Plane(data, type)}
        };
        public static T CreateVehicle<T>(string data, string type) where T : Vehicle {
            if (!_factories.ContainsKey(typeof(T)))
                throw new Exception("Cannot create Vehicle of type " + typeof(T).Name);
            return (T) _factories[typeof(T)](data, type);
        }
        public static Vehicle CreateVehicle(Type vehicleType, string data, string type) {
            if (!_factories.ContainsKey(vehicleType))
                throw new Exception("Cannot create Vehicle of type " + vehicleType.Name);
            return _factories[vehicleType](data, type);
        }
    }
