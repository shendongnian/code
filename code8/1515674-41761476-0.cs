    private static readonly BindableProperty controlProperty = BindableProperty.Create("Test1", typeof(ICommand), typeof(Control1), null);
    public ICommand Test1
    {
        get { return (ICommand)GetValue(controlProperty); }
        set { SetValue(controlProperty, value); }
    }
