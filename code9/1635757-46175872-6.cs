    Bind<IDeviceState>().To<OnlineState>().Named("Online");
    Bind<IDeviceState>().To<OfflineState>().Named("Offline");
    public Modem([Named("Online")] IDeviceState state){
        _state = state;
    }
