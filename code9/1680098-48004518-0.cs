    //This will create instance of the page using the parameterized constructor you defined in each DetailPages
    Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType, myStringParam));
    
    
    //Your Each Detail Page should have parametrized constructor.
    public MyPage (string param)
    {
        InitializeComponent ();
        Browser.Source = param;
    }
