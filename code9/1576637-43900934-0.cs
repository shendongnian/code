    private static void OnTypeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var src = (TextBox)d;
        var dpd = DependencyPropertyDescriptor.FromProperty(TextBox.TextProperty, typeof(TextBox));
        dpd.AddValueChanged(src, UpdateBindingHandler);
        UpdateBinding(src);
    }
    protected static void UpdateBindingHandler(object sender, EventArgs e)
    {
        UpdateBinding((TextBox)sender);
    }
    private static void UpdateBinding(TextBox tbox)
    {
        var binding = BindingOperations.GetBinding(tbox, TextBox.TextProperty);
        if (binding != null)
        {
            binding.Converter = new NumberConverter();
            binding.ConverterParameter = GetType(tbox);
            var dpd = DependencyPropertyDescriptor.FromProperty(TextBox.TextProperty, typeof(TextBox));
            //  Don't do this every time the value changes, only the first time 
            //  it changes after TxtBox.Type has changed. 
            dpd.RemoveValueChanged(tbox, UpdateBindingHandler);
        }
    }
