	public class Area
	{
		public string area { get; set; }
		public override string ToString()
		{
			return area;
		}
	}
	public class Controller
	{
		public string controller { get; set; }
		public override string ToString()
		{
			return controller;
		}
	}
	public class Action
	{
		public string action { get; set; }
		public override string ToString()
		{
			return action;
		}
	}
	private Dictionary<Area, Dictionary<Controller, Action>> ActionCollection;
