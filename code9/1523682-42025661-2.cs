    public interface IVehicleRepository<T> where T : Vehicle
    {
        void Add(T item);
        IEnumerable<T> GetAll();
        Vehicle Find(string key);
        Vehicle Remove(string key);
        void Update(T item);
    }
