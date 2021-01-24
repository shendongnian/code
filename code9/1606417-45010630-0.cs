    public static readonly DependencyProperty NumericValueProperty =
        DependencyProperty.Register(
            "NumericValue", typeof(decimal), typeof(DecimalTextBox),
            new PropertyMetadata(NumericValuePropertyChanged));
    public decimal NumericValue
    {
        get { return (decimal)GetValue(NumericValueProperty); }
        set { SetValue(NumericValueProperty, value); }
    }
    private static void NumericValuePropertyChanged(
        DependencyObject obj, DependencyPropertyChangedEventArgs e)
    {
        var textBox = (DecimalTextBox)obj;
        textBox.Text = e.NewValue.ToString();
    }
