    public partial class Window1 : Window
    {
    	public RegisterMode Mode
    	{
    		get { return (RegisterMode)GetValue(ModeProperty); }
    		set { SetValue(ModeProperty, value); }
    	}
    
    	// Using a DependencyProperty as the backing store for Mode.  This enables animation, styling, binding, etc...
    	public static readonly DependencyProperty ModeProperty =
    		DependencyProperty.Register("Mode", typeof(RegisterMode), typeof(Window1), new PropertyMetadata(RegisterMode.None));
    
    	public Window1()
    	{
    		InitializeComponent();
    		
    		/* THIS IS NOT NEEDED
    		Binding modeBinding = new Binding();
    		modeBinding.Source = this.DataContext;
    		modeBinding.Path = new PropertyPath("Mode");
    		modeBinding.Mode = BindingMode.TwoWay;
    		modeBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
    		this.SetBinding(Window1.ModeProperty, modeBinding)
    		*/
    		
    		// Use the following instead:
    		this.DataContext = new WindowViewModel();
    	}
    
    	private void Button_Click(object sender, RoutedEventArgs e)
    	{
    		MessageBox.Show((uc1.DataContext as UCViewModel).Mode.ToString());
    	}
    }
