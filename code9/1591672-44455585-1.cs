    public string WindowTitle
    {
        get
        {
            return (string)GetValue(WindowTitleProperty);
        }
        set
        {
            SetValue(WindowTitleProperty, value);
        }
    }
    public static readonly DependencyProperty WindowTitleProperty =
               DependencyProperty.Register("WindowTitle", typeof(string), typeof(Editor), new UIPropertyMetadata("Editor"));
