    static void Initialize()
    {
        //Do the stuff you want to have in both main and code
    }
    static void Main (string[] args)
    {
        Initialize();
        code();
    }
    static void code()
    {
        if (condition /*you said there'd be some if statement*/)
            Initialize();
    }
