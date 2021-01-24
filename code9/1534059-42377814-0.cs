    using (GpioPin pin1 = gpio.OpenPin(5))
    {
        pin1.Write(GpioPinValue.High);
        pin1.SetDriveMode(GpioPinDriveMode.Output);
    }
