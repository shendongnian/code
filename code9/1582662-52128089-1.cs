    public MainViewModel()
    {
        _io = ServiceContainer.Instance.Get<IO>();
        _brakingPin = _io.OpenPin(4, GpioSharingMode.Exclusive);
        _io.SetDriveMode(_brakingPin, GpioPinDriveMode.Output);
        _io.Write(_brakingPin, GpioPinValue.Low);
    }
