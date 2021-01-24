	public class RootObject
    {
        public string cmd { get; set; }
        public string model { get; set; }
        public string sid { get; set; }
        public int short_id { get; set; }
        public SensorData data { get; set; }
    }
	
	public abstract class SensorData
	{		
	}
	
	public class MagnetData : SensorData
	{
		public int Voltage { get; set; }
	}
	
	public class SomeOtherSensorData : SensorData
	{
		public bool AnotherProperty { get; set; }
	}
