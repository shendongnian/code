    Bind<IDeviceState>().To<OnlineState>().Named("Online");
    Bind<IDeviceState>().To<OfflineState>().Named("Offline");
    public Samurai([Named("Online")] IDeviceState state){
        _state = state;
    }
