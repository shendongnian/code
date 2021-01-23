    public static readonly DependencyProperty TextBoxTextProperty =
        DependencyProperty.Register(
            "TextBoxText", typeof(string), typeof(TextBoxUnitConvertor),
            new PropertyMetadata(TextBoxTextPropertyChanged));
    private static void TextBoxTextPropertyChanged(
        DependencyObject o, DependencyPropertyChangedEventArgs e)
    {
        TextBoxUnitConvertor t = (TextBoxUnitConvertor)o;
        t.CurrentValue = ...
    }
