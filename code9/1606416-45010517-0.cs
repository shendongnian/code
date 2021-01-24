    // Using a DependencyProperty as the backing store for NumericValue.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty NumericValueProperty =
        DependencyProperty.Register("NumericValue", typeof(decimal), typeof(DecimalTextBox), new FrameworkPropertyMetadata(0.0m, new PropertyChangedCallback(OnNumericValueChanged)));
    private static void OnNumericValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var self = d as DecimalTextBox;
        // if the new numeric value is different from the text value, update the text
    }
