	public class RootObject
	{
		public RootObject() { this.valores = new Dictionary<string, Valores>(); }
		
		public bool status { get; set; }
		public Dictionary<string, Valores> valores { get; set; }
	}
