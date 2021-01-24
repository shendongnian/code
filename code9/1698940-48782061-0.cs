    class Program
    {        
        static void Main(string[] args)
        {
            var monitor = new Monitor();
            monitor.PropertyChanged += DoSomething;
            monitor.StartMonitoring();
        }
        void DoSomething(object sender, PropertyChangedEventArgs e) 
        {
            // This ensures that only the SensorValue property will handled.
            if (e.PropertyName != nameof(Monitor.SensorValue))
                return;
            // ... Do something with Monitor.SensorValue
        }
    }
