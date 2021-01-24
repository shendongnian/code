    public MyContainer()
    {
    	InitializeComponent();
    	this.PreviewMouseDown += MyContainer_PreviewMouseDown;
    }
    
    private void MyContainer_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
    	var source = e.OriginalSource as FrameworkElement;
    	var dataContext = source?.DataContext;
    	if(dataContext.GetType() == typeof(ProperViewModel))
    	{
    		((ProperViewModel)dataContext).Command_Execute();
    	}
    }
