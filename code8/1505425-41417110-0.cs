	public class FruitItem {
		public string Name { get; set; }
		public int Failed { get; set; }
		public int Succeeded { get; set; }
		public int Service { get; set; }
		public FruitItem(string name, int failed, int succeeded, int service) {
			Name = name;
			Failed = failed;
			Succeeded = succeeded;
			Service = service;
		}
    }
