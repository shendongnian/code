    public partial class ProcessXML : UserControl
    {
    	public ProcessXML()
    	{
    		InitializeComponent();
    	}
    
    	DependencyProperty ParentViewModelProperty = DependencyProperty
    		.Register("ParentViewModel", typeof(ViewModelType), typeof(ProcessXML), new PropertyMetadata(null));
    
    	public ViewModelType ParentViewModel
    	{
    		get { return (ViewModelType)GetValue(ParentViewModelProperty); }
    		set { SetValue(ParentViewModelProperty, value); }
    	}
    }
