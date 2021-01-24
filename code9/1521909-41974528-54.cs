    public partial class Window
	{
    
	    public Window()
	    {
            InitializeComponent();
	    	this.DataContext = this;
	    }
	
	    public Module Module1 { get; set; } = new Module(); //in this case You do not need ViewModel
	}
	
	
