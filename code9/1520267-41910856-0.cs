    public class Sensor
    {
        const double Offset = 16;
        Func<double> _getFuelTelemetry;
        public Sensor(Func<double> getFuelTelemetry)
        {
            _getFuelTelemetry = getFuelTelemetry;
        }
        public Sensor()
            : this(SampleAmount)
        {
        }
        public double GetFuelAmountValue()
        {
            double value = _getFuelTelemetry();
            return Offset + value;
        }
        private static double SampleAmount()
        {
            Random basicRandomNumbersGenerator = new Random();
            return basicRandomNumbersGenerator.Next(0, 25);
        }
    }
    public class Indicator
    {
        private const double LowFuelTreshold = 7;
        private const double HighFuelTreshold = 21;
    
        Sensor _sensor;
    
        public Indicator(Sensor sensor)
        {
            _sensor = sensor;
        }
    
        public Indicator() : this(new Sensor())
        {
        }
    
        bool _alarm = false;
        private long _alarmCount = 0;
    
    
        public void Check()
        {
            double LitersOfFuelValue = _sensor.GetFuelAmountValue();
    
            if (LitersOfFuelValue < LowFuelTreshold || HighFuelTreshold < LitersOfFuelValue)
            {
                _alarm = true;
                _alarmCount += 1;
            }
        }
    
        public bool Alarm
        {
            get { return _alarm; }
        }
    
    }
    [TestClass]
    public class FuelIndicatorTest
    {
        [TestMethod]
        public void Foo()
        {
            Indicator indicator = new Indicator(new Sensor(() => {return 25;}));
            indicator.Check();
            Assert.AreEqual(false, indicator.Alarm);
        }
    }
