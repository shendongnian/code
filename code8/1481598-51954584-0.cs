    public partial class MyFrame : Frame
    {
    	#region Dependency Properties
    	public bool AllowForwardNavigation
    	{
    		get { return (bool)GetValue(AllowForwardNavigationProperty); }
    		set { SetValue(AllowForwardNavigationProperty, value); }
    	}
    
    	public static readonly DependencyProperty AllowForwardNavigationProperty =
    		DependencyProperty.Register(nameof(AllowForwardNavigation), typeof(bool), typeof(MyFrame), new PropertyMetadata(true));
    
    	public bool AllowBackNavigation
    	{
    		get { return (bool)GetValue(AllowBackNavigationProperty); }
    		set { SetValue(AllowBackNavigationProperty, value); }
    	}
    
    	public static readonly DependencyProperty AllowBackNavigationProperty =
    		DependencyProperty.Register(nameof(AllowBackNavigation), typeof(bool), typeof(MyFrame), new PropertyMetadata(true));
    
    	#endregion
    
    	public MyFrame()
    	{
    		InitializeComponent();
    
    		JournalOwnership = JournalOwnership.OwnsJournal;
    
    
    		// find existing bindings
    		var existingBindings = CommandBindings.OfType<CommandBinding>()
    											  .Where(x => x.Command == NavigationCommands.BrowseForward
    													   || x.Command == NavigationCommands.BrowseBack)
    											  .ToArray();
    
    		// remove existing bindings
    		foreach (var binding in existingBindings)
    			CommandBindings.Remove(binding);
    
    		// add new binding
    		CommandBindings.Add(new CommandBinding(NavigationCommands.BrowseForward, OnGoForward, OnQueryGoForward));
    		CommandBindings.Add(new CommandBinding(NavigationCommands.BrowseBack, OnGoBack, OnQueryGoBack));
    
    		// override default navigation behavior
    		NavigationService.Navigating += NavigationService_Navigating;
    	}
    
    	private void NavigationService_Navigating(Object sender, NavigatingCancelEventArgs e)
    	{
    		switch (e.NavigationMode)
    		{
    			case NavigationMode.Forward:
    				e.Cancel = !AllowForwardNavigation;
    				break;
    			case NavigationMode.Back:
    				e.Cancel = !AllowBackNavigation;
    				break;
    		}
    	}
    
    	#region Command methods
    	private void OnGoForward(Object sender, ExecutedRoutedEventArgs e)
    	{
    		e.Handled = true;
    		if (AllowForwardNavigation && NavigationService.CanGoForward)
    			NavigationService.GoForward();
    	}
    
    	private void OnQueryGoForward(Object sender, CanExecuteRoutedEventArgs e)
    	{
    		e.Handled = true;
    		e.CanExecute = AllowForwardNavigation && NavigationService.CanGoForward;
    	}
    
    	private void OnGoBack(Object sender, ExecutedRoutedEventArgs e)
    	{
    		e.Handled = true;
    		if (AllowBackNavigation && NavigationService.CanGoBack)
    			NavigationService.GoBack();
    	}
    
    	private void OnQueryGoBack(Object sender, CanExecuteRoutedEventArgs e)
    	{
    		e.Handled = true;
    		e.CanExecute = AllowBackNavigation && NavigationService.CanGoBack;
    	}
    	#endregion
    }
