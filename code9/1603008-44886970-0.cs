    public string Text
    {
        get
        {
            return (string)GetValue(TextProperty);
        }
        set
        {
            SetValue(TextProperty, value);
        }
    }
    static AutoCompleteTextBox()
    {
        SuggestionsProperty = DependencyProperty.Register(nameof(Suggestions), typeof(List<string>), typeof(AutoCompleteTextBox));
        TextProperty = DependencyProperty.Register(nameof(Text), typeof(string), typeof(AutoCompleteTextBox),
            new FrameworkPropertyMetadata(null, new PropertyChangedCallback(OnTextChanged)) { BindsTwoWayByDefault = true });
    }
    private static void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        AutoCompleteTextBox ctrl = d as AutoCompleteTextBox;
        ctrl.textBox.Text = e.NewValue as string;
    }
