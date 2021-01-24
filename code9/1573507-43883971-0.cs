    public class Uln2003Driver : IDisposable
    {
        private readonly GpioPin[] _gpioPins = new GpioPin[4];
        private readonly GpioPinValue[][] _waveDriveSequence =
        {
            new[] {GpioPinValue.High, GpioPinValue.Low, GpioPinValue.Low, GpioPinValue.Low},
            new[] {GpioPinValue.Low, GpioPinValue.High, GpioPinValue.Low, GpioPinValue.Low},
            new[] {GpioPinValue.Low, GpioPinValue.Low, GpioPinValue.High, GpioPinValue.Low},
            new[] {GpioPinValue.Low, GpioPinValue.Low, GpioPinValue.Low, GpioPinValue.High}
        };
        private readonly GpioPinValue[][] _fullStepSequence =
        {
            new[] {GpioPinValue.High, GpioPinValue.Low, GpioPinValue.Low, GpioPinValue.High},
            new[] {GpioPinValue.High, GpioPinValue.High, GpioPinValue.Low, GpioPinValue.Low},
            new[] {GpioPinValue.Low, GpioPinValue.High, GpioPinValue.High, GpioPinValue.Low},
            new[] {GpioPinValue.Low, GpioPinValue.Low, GpioPinValue.High, GpioPinValue.High }
        };
        private readonly GpioPinValue[][] _haveStepSequence =
        {
            new[] {GpioPinValue.High, GpioPinValue.High, GpioPinValue.Low, GpioPinValue.Low, GpioPinValue.Low, GpioPinValue.Low, GpioPinValue.Low, GpioPinValue.High},
            new[] {GpioPinValue.Low, GpioPinValue.High, GpioPinValue.High, GpioPinValue.High, GpioPinValue.Low, GpioPinValue.Low, GpioPinValue.Low, GpioPinValue.Low},
            new[] {GpioPinValue.Low, GpioPinValue.Low, GpioPinValue.Low, GpioPinValue.High, GpioPinValue.High, GpioPinValue.High, GpioPinValue.Low, GpioPinValue.Low},
            new[] {GpioPinValue.Low, GpioPinValue.Low, GpioPinValue.Low, GpioPinValue.Low, GpioPinValue.Low, GpioPinValue.High, GpioPinValue.High, GpioPinValue.High }
        };
        public Uln2003Driver(int blueWireToGpio, int pinkWireToGpio, int yellowWireToGpio, int orangeWireToGpio)
        {
            var gpio = GpioController.GetDefault();
            _gpioPins[0] = gpio.OpenPin(blueWireToGpio);
            _gpioPins[1] = gpio.OpenPin(pinkWireToGpio);
            _gpioPins[2] = gpio.OpenPin(yellowWireToGpio);
            _gpioPins[3] = gpio.OpenPin(orangeWireToGpio);
            foreach (var gpioPin in _gpioPins)
            {
                gpioPin.Write(GpioPinValue.Low);
                gpioPin.SetDriveMode(GpioPinDriveMode.Output);
            }
        }
        public async Task TurnAsync(int degree, TurnDirection direction,
            DrivingMethod drivingMethod = DrivingMethod.FullStep)
        {
            var steps = 0;
            GpioPinValue[][] methodSequence;
            switch (drivingMethod)
            {
                case DrivingMethod.WaveDrive:
                    methodSequence = _waveDriveSequence;
                    steps = (int) Math.Ceiling(degree/0.1767478397486253);
                    break;
                case DrivingMethod.FullStep:
                    methodSequence = _fullStepSequence;
                    steps = (int) Math.Ceiling(degree/0.1767478397486253);
                    break;
                case DrivingMethod.HalfStep:
                    methodSequence = _haveStepSequence;
                    steps = (int) Math.Ceiling(degree/0.0883739198743126);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(drivingMethod), drivingMethod, null);
            }
            var counter = 0;
            while (counter < steps)
            {
                for (var j = 0; j < methodSequence[0].Length; j++)
                {
                    for (var i = 0; i < 4; i++)
                    {
                        _gpioPins[i].Write(methodSequence[direction == TurnDirection.Left ? i : 3 - i][j]);
                    }
                    await Task.Delay(5);
                    counter ++;
                    if (counter == steps)
                        break;
                }
            }
            Stop();
        }
        public void Stop()
        {
            foreach (var gpioPin in _gpioPins)
            {
                gpioPin.Write(GpioPinValue.Low);
            }
        }
        public void Dispose()
        {
            foreach (var gpioPin in _gpioPins)
            {
                gpioPin.Write(GpioPinValue.Low);
                gpioPin.Dispose();
            }
        }
    }
    public enum DrivingMethod
    {
        WaveDrive,
        FullStep,
        HalfStep
    }
    public enum TurnDirection
    {
        Left,
        Right
    }`
