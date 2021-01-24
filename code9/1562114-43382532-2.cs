    public partial class VPage : Page
    {
    	public ViewModel viewModel;
    
    	public VPage()
    	{
    		DataContext = viewModel = new ViewModel();
    		InitializeComponent();
    
    		Loaded += OnLoaded;
    	}
    
    	private void OnLoaded(object sender, RoutedEventArgs e)
    	{
    		viewModel.onNavigatedTo();
    	}
    
    	private void onTap(object sender, TappedRoutedEventArgs eventArgs) { viewModel.onTap(); }
    }
