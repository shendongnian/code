    List<List<object>> _systems = new List<List<object>>();
    public void AddSystem<T>(int position = -1) where T : class
    {
        var system = new List<T>();
        _systems.Add(system);
    }
