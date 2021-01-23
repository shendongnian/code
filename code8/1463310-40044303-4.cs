    public partial class MainWindow : Window
    	{
    		private IDrawable clicked;
    
    		public ObservableCollection<IDrawable> list { get; set; }
    		public IDrawable sel { get; set; }
    
    		public MainWindow()
    		{
    			InitializeComponent();
    			list = new ObservableCollection<IDrawable>();
    			list.Add(new MyLabel());
    			list.Add(new MyLabelButton());
    			list.Add(new MyButton());
    			this.DataContext = this;
    		}
    
    		private void ComboBox_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    		{
    			Point pt = e.GetPosition(MyGrid);
    
    			clicked = null;
    			VisualTreeHelper.HitTest(
    				MyGrid,
    				null,
    				new HitTestResultCallback(ResultCallback),
    				new PointHitTestParameters(pt));
    
    
    			if (clicked != null)
    			{
    				((ComboBox)sender).IsDropDownOpen = false;
    
    				//do something
    			}
    		}
    
    		private HitTestResultBehavior ResultCallback(HitTestResult result)
    		{
    			DependencyObject parentObject = VisualTreeHelper.GetParent(result.VisualHit);
    
    			if (parentObject == null)
    				return HitTestResultBehavior.Continue;
    
    			var v = parentObject as Button;
    
    			if (v == null)
    				return HitTestResultBehavior.Continue;
    
    			if (v.DataContext != null && v.DataContext is IDrawable)
    			{
    				clicked = (IDrawable)v;
    				return HitTestResultBehavior.Stop;
    			}
    			return HitTestResultBehavior.Continue;
    		}
    	}
