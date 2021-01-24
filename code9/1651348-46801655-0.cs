	class Vital
	{
		public Vital(VitalName name) => Name = name;
		public int baseValue;
		public int currValue;
		public VitalName Name { get; }
		public override bool Equals(object obj)
		{
			return obj is Vital vital && Name == vital.Name;
		}
		public override int GetHashCode()
		{
			return 539060726 + Name.GetHashCode();
		}
	}
