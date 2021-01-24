    public ILocationProvider GetLocationProvider()
    {
      return _locationProvider
    }
    public void SetLocationProvider(ILocationProvider locationProvider)
    {
      if(_locationProvider != null)
      {
        // unsubscribe events
      }
      _locationProvider = locationProvider;
      // subscribe events
    }
