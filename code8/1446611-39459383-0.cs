    public async Task<Dictionary<int, BusStop>> GetBusStopsAsync() { ... }
    public NotifyTask<Dictionary<int, BusStop>> BusStops { get; }
    MyViewModelConstructor()
    {
      BusStops = NotifyTask.Create(() => GetBusStopsAsync());
    }
