    if(item.TargetType == typeof(WebPage))
    {
        Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType, myStringParam));
    }
    else
    {
        Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
    }
    
    //Your Page would be:
    public WebPage (string URL)
    {
        InitializeComponent ();
        Browser.Source = URL;
    }
 
