	public partial class MyPageViewController : UIPageViewController, IUIPageViewControllerDataSource
    {
		List<UIViewController> MyViewControllers = new List<UIViewController>();
        public MyPageViewController (IntPtr handle) : base (handle)
        {
			
        }
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			var redViewController = UIStoryboard.FromName("Main", null).InstantiateViewController("redViewController");
			var greenViewController = UIStoryboard.FromName("Main", null).InstantiateViewController("greenViewController");
			var blueViewController = UIStoryboard.FromName("Main", null).InstantiateViewController("blueViewController");
			MyViewControllers.Add(redViewController);
			MyViewControllers.Add(greenViewController);
			MyViewControllers.Add(blueViewController);
			DataSource = this;
			SetViewControllers(new UIViewController[] { MyViewControllers.First() }, UIPageViewControllerNavigationDirection.Forward, true, null);
		}
		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
		}
		UIViewController IUIPageViewControllerDataSource.GetNextViewController(UIPageViewController pageViewController, UIViewController referenceViewController)
		{
			var index = MyViewControllers.IndexOf(referenceViewController);
			var nextIndex = index + 1;
			return MyViewControllers.ElementAtOrDefault(nextIndex);
		}
		UIViewController IUIPageViewControllerDataSource.GetPreviousViewController(UIPageViewController pageViewController, UIViewController referenceViewController)
		{
			var index = MyViewControllers.IndexOf(referenceViewController);
			var previousIndex = index - 1;
			return MyViewControllers.ElementAtOrDefault(previousIndex);
		}
	}
