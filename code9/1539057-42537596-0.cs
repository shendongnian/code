	public class Man {
		public Man(){} // optional, but do not include the constructor you had as it sets the private fields directly OR include additional validation
		private string name;
		public string Name
		{
			get { return name; }
			set
			{
				if (string.IsNullOrEmpty(value))
					throw new ArgumentNullException("Name cannot be null or empty");
				name = value;
			}
		}
	}
