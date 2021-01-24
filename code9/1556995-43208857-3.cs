    public partial class UserControl1 : UserControl
    {
    
    	public RegisterMode Mode
    	{
    		get { return (RegisterMode)GetValue(ModeProperty); }
    		set { SetValue(ModeProperty, value); }
    	}
    
    	// Using a DependencyProperty as the backing store for Mode.  This enables animation, styling, binding, etc...
    	public static readonly DependencyProperty ModeProperty =
    		DependencyProperty.Register("Mode", typeof(RegisterMode), typeof(UserControl1), new PropertyMetadata(RegisterMode.None));
    
    
    	public UserControl1()
    	{
    		InitializeComponent();
    
    		/* THIS IS NOT NEEDED
    		Binding modeBinding = new Binding();
    		modeBinding.Source = this.DataContext;
    		modeBinding.Path = new PropertyPath("Mode");
    		modeBinding.Mode = BindingMode.TwoWay;
    		modeBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
    		this.SetBinding(UserControl1.ModeProperty, modeBinding);
    		*/
    	}
    }
