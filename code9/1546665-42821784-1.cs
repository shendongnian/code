    private string _greeting;
    public string Greeting 
    {
        get
        {
            return $"My Name is: {_greeting}";
        }
        set
        {
            _greeting = value;
        } 
    }
