    class Program
    {
        public ISensorMonitor Sensor1 { get; }
        public ISensorMonitor Sensor2 { get; }
        public ISensorMonitor Sensor3 { get; }
        public ISensorMonitor Sensor4 { get; }
        static void Main(string[] args)
        {
            // In this example Sensor1Monitor would implement ISensorMonitor
            Sensor1 = new Sensor1Monitor();
            Sensor1.PropertyChanged += DoSomethingWithSensor1;
            Sensor1.StartMonitoring();
            // ... implement the other 3 sensors.
        }
        void DoSomethingWithSensor1(object sender, PropertyChangedEventArgs e) 
        {
            // This ensures that only the SensorValue property will handled.
            if (e.PropertyName != nameof(ISensorMonitor.SensorValue))
                return;
            // ... Do something with Sensor1.SensorValue
        }
        // ... implement the other 3 sensors.
    }
