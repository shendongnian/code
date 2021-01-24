    public class ViewControllerHolder
	{
		// make constructor private to force use of Instance property
		// to create and get the instance.
		private ViewControllerHolder()
		{
		}
		private static ViewControllerHolder _instance;
		public static ViewControllerHolder Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new ViewControllerHolder();
					_instance.Controllers = new List<UIViewController>();
				}
				return _instance;
			}
		}
		public List<UIViewController> Controllers { get; private set; }
	}
