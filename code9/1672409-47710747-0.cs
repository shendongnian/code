    public MyButton()
    {
        InitializeComponent();
        (this.Content as FrameworkElement).DataContext = this;
    }
    public ImageSource Icon
    {
        get => (ImageSource)GetValue(s_iconProperty);
        set => SetValue(s_iconProperty, value);
    }
