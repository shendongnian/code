	public class SelectListItem
	{
		public virtual string Text { get; set; }
		public virtual string Value { get; set; }
	}
	public class City : SelectListItem
	{
		public int CityId { get; set; }
		public string CityName { get; set; }
		public override string Text
		{
			get { return CityName; }
			set { CityName = value; }
		}
		public override string Value
		{
			get { return CityId.ToString();	}
			set { CityId = (int)value; }
		}
	}
	public class State : SelectListItem
	{
		public int StateId { get; set; }
		public string StateName { get; set; }
		public string StateAbbreviation { get; set; }
		public override string Text
		{
			get { return StateName; }
			set { StateName = value; }
		}
		public override string Value
		{
			get { return StateId.ToString(); }
			set { StateId = (int)value; }
		}
	}
