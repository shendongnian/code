    public string Name
    {
        get => name;
        set => name = value ?? throw new ArgumentNullException();
    }
