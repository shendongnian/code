    public string TextBoxText
            {
                get { return (string)GetValue(TextBoxTextProperty); }
                set { SetValue(TextBoxTextProperty, value); }
            }
    
    public static readonly DependencyProperty TextBoxTextProperty =
                DependencyProperty.Register("TextBoxText", typeof(string), typeof(TextBoxUnitConvertor), new PropertyMetadata(""));
