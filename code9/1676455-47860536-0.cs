    private static UserControlName _instance;
    public static UserControlName Instance
    {
        get
        {
            if (_instance == null)
                _instance = new UserControlName();
            return _instance;
        }
    }
