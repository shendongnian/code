    //Methods have to be static when using a field initializer
    //Func<string> returns a string and has no paramters
    private static Dictionary<string, Func<string>> _colorFunc = new Dictionary<string, Func<string>>()
    {
        {"Green", GreenFunc},
        {"Orange", BlueFunc}
        ....
    };
    private static string GreenFunc()
    {
        // green logic
        return "Red";
    }
    //Usage
    public string OppositeColor(string color)
    {
        return _colorFunc[color]();
    }
    
