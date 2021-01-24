	public class Data
	{
		public double Value { get; private set; }
		public Data(double value) { this.Value = value;	}
	
		public Data Times2Add1()
		{
			this.Value = this.Value * 2.0 + 1.0;
			return this;
		}
	
		public Data Divide3()
		{
			this.Value = this.Value / 3.0;
			return this;
		}
	}
