    public Form()
    {
        InitializeComponent();
        DataContext = new 
            {
                CBItems = new[] {
                    new SelectMethodCallItem("sin(float x)"),
                    new SelectMethodCallItem("cos(float x)"),
                    new SelectMethodCallItem("foobar(string s)"),
                }
            };
    }
