	public class Data
	{
		public double Value { get; private set; }
		public Data(double value) { this.Value = value; }
	
		public Data Times2Add1()
		{
			return new Data(this.Value * 2.0 + 1.0);
		}
	
		public Data Divide3()
		{
			return new Data(this.Value / 3.0);
		}
	}
