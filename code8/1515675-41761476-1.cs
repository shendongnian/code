    public static readonly BindableProperty Test1Property = BindableProperty.Create("Test1", typeof(ICommand), typeof(Control1), null);
    public ICommand Test1
    {
        get { return (ICommand)GetValue(Test1Property); }
        set { SetValue(Test1Property, value); }
    }
