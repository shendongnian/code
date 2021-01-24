    private static Form1 instance;
    public static Form1 Default
    {
        get
        {
            if (instance == null)
                instance = new Form1();
            return instance;
        }
    }
