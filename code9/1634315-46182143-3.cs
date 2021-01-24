	public MainWindow() 
	{ 
		InitializeComponent(); 
		// Disables inking in the WPF application and enables us to track touch events to properly trigger the touch keyboard 
		InkInputHelper.DisableWPFTabletSupport(); 
		this.Loaded += MainWindow_Loaded; 
	} 
	private void MainWindow_Loaded(object sender, RoutedEventArgs e) 
	{ 
		System.Windows.Automation.AutomationElement asForm = 
			System.Windows.Automation.AutomationElement.FromHandle(new WindowInteropHelper(this).Handle); 
		
		InputPanelConfigurationLib.InputPanelConfiguration inputPanelConfig = new InputPanelConfigurationLib.InputPanelConfiguration(); 
		inputPanelConfig.EnableFocusTracking(); 
	} 
