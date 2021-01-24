    private void SW_btnMouseOverHighlight(object sender, MouseEventArgs e)
    {
        var obj = (DependencyObject)sender;
        var background = obj.GetValue(Control.BackgroundProperty) as SolidColorBrush;
        if (background != null)
        {
            var color = background.Color;
            ...
            obj.SetCurrentValue(Control.BackgroundProperty, new SolidColorBrush(color));
        }
    }
