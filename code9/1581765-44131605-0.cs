    public sealed partial class MainPage : Page
    {
        private const int SENSOR_PIN = 27;
        private GpioPin pin;
        private GpioPinValue pinValue;
        private DispatcherTimer timer;
        public MainPage()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(1000);
            timer.Tick += ReadSensor;
            InitGPIO();
            if (pin != null)
            {
                timer.Start();
            }
        }
        private void InitGPIO()
        {
            var gpio = GpioController.GetDefault();
            // Show an error if there is no GPIO controller
            if (gpio == null)
            {
                pin = null;
                System.Diagnostics.Debug.WriteLine("There is no GPIO controller on this device.");
                return;
            }
            pin = gpio.OpenPin(SENSOR_PIN);
            pin.SetDriveMode(GpioPinDriveMode.Input);
            System.Diagnostics.Debug.WriteLine("GPIO pin initialized correctly.");
        }
        private void ReadSensor(object sender, object e)
        {
            SensorOuputValue.Text = pin.Read().ToString();
        }
    }
