    private readonly string _widgetName = GetWidgetName();
    public string `
    {
        get 
        {
            if (_widgetName == null) throw new Exception("Value is not set"); 
            return _widgetName; 
        }
    }
