    public static int StaticVariable { get; set; }//First Method
    public int PublicProperty { get; set; }
    public Form2(int Value)
    {
    	InitializeComponent();
    	//Do your code here with constructor way here
    }
    public Form2()
    {
    	InitializeComponent();
    }
    protected override void OnLoad(EventArgs e)
    {
    	base.OnLoad(e);
    	//Do your code for 1,2 here
    }
    
    public void SetValueWithFunction(int value)
    {
    	//Do your code for setting value with second type in Number 3
    }
