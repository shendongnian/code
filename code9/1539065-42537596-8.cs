	public class Man {
        public Man(string name)
        {
            // notice capital N for Name so it is set on the property, not the field
            // this will execute the setter for the Name property
            this.Name = name;
        }
		public Man(){} // optional, but do not include the parameterized constructor you had as it sets the private fields directly OR include additional validation
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
