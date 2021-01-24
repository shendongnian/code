    public static readonly DependencyProperty ButtonThemeProperty =
        DependencyProperty.Register(
            "ButtonTheme",
            typeof(Theme),
            typeof(BugButton),
            new PropertyMetadata(Theme.Black, new PropertyChangedCallback(ValueChanged)));
