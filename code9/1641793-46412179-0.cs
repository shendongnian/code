    public static readonly DependencyProperty Value25Property = DependencyProperty.Register(
    	"Value25", 
    	typeof(double), 
    	typeof(MainWindow));
    	
    public double Value25
    {
    	get { return (double) GetValue(Value25Property); }
    	set { SetValue(Value25Property, value); }
    }
