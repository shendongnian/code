    public partial class MainWindow : Window
	{
		public bool _isInDrag = false;
		public Dictionary<object, TranslateTransform> PointDict = new Dictionary<object, TranslateTransform>();
		public Point _anchorPoint;
		public Point _currentPoint;
		public MainWindow()
		{
			InitializeComponent();
		}
		public void Control_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			if (_isInDrag)
			{
				var element = sender as FrameworkElement;
				element.ReleaseMouseCapture();
				Panel.SetZIndex(element, 0);
				_isInDrag = false;
				e.Handled = true;
			}
		}
		public void Control_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			var element = sender as FrameworkElement;
			_anchorPoint = e.GetPosition(null);
			element.CaptureMouse();
			Panel.SetZIndex(element, 10);
			_isInDrag = true;
			e.Handled = true;
		}
		public void Control_MouseMove(object sender, MouseEventArgs e)
		{
			if (_isInDrag)
			{
				_currentPoint = e.GetPosition(null);
				FrameworkElement fw = sender as FrameworkElement;
				if (fw != null)
				{
					FrameworkElement fwParent = fw.Parent as FrameworkElement;
					if (fwParent != null)
					{
						Point p = new Point(_currentPoint.X - _anchorPoint.X + Canvas.GetLeft((sender as UIElement)), _currentPoint.Y - _anchorPoint.Y + Canvas.GetTop((sender as UIElement)));
						List<HitTestResult> lst = new List<HitTestResult>()
						{
							VisualTreeHelper.HitTest(fwParent  , p),
							VisualTreeHelper.HitTest(fwParent, new Point(p.X + fw.Width, p.Y)),
							VisualTreeHelper.HitTest(fwParent, new Point(p.X, p.Y + fw.Height)),
							VisualTreeHelper.HitTest(fwParent, new Point(p.X + fw.Width, p.Y +fw.Height)),
						};
						bool success = true;
						foreach (var item in lst)
						{
							if (item != null)
							{
								if (item.VisualHit != sender && item.VisualHit != fwParent && fw.IsAncestorOf(item.VisualHit) == false)
								{
									success = false;
									break;
								}
							}
						}
						if (success)
						{
							Canvas.SetTop((sender as UIElement), p.Y);
							Canvas.SetLeft((sender as UIElement), p.X);
							_anchorPoint = _currentPoint;
						}
					}
				}
			}
		}
	}
