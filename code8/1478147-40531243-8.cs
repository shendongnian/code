    private MySingletonViewModel()
    {
        //  stuff
    }
    public static MySingletonViewModel Instance { get; private set; }
    
    //  Static constructor
    static MySingletonViewModel()
    {
        Instance = new MySingletonViewModel();
    }
