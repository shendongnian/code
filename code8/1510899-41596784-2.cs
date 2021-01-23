	class Program
	{
		static void Main(string[] args)
		{
			ConcreteChannel channel = new ConcreteChannel();
			ConcreteSensor sensor = new ConcreteSensor();
            // "plugging" a sensor into a channel
			channel.Sensor = sensor;
            // "sensor" works as a data source for other client code
			sensor.WhenNewSamples.Subscribe(Console.WriteLine);
            // channel works as a data target for data coming from some server class
			channel.AddSamples(Enumerable.Range(0, 10).Select(Convert.ToDouble));
		}
	}
