	public class aClass
	{
		public int PropA { get; set; } = 1;
		public int PropB { get; set; } = 18;
		public int PropC { get; set; } = 25;
		public int GetMaxConfiguratableColumns()
		{
			return new List<int> {this.PropA, this.PropB, this.PropC}.Max();
		}
	}
