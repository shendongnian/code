    // in App.xaml.cs
    public static new App Current { get; private set; }
    
    public App()
    {
        Current = this;
        // Another code
    }
