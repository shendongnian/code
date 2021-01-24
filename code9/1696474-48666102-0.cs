    public static readonly BindableProperty SearchTextProperty =
        BindableProperty.Create(nameof(SearchText), typeof(string), typeof(MyCustomClass), string.Empty);
			
    public string SearchText
    {
        get { return (string)GetValue(SearchTextProperty); }
        set { SetValue(SearchTextProperty, value); }
    }
