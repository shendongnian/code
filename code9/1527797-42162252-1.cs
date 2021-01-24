    private Size MeasureString(string textToMeasure, Size availableSize, double fontSize, string fontFamily)
    {
        var tb = new TextBlock();
        tb.TextWrapping = TextWrapping.Wrap;
        tb.Text = textToMeasure;
        tb.FontFamily = new FontFamily(fontFamily);
        tb.FontSize = fontSize;
        tb.Measure(new Size(Double.PositiveInfinity, double.PositiveInfinity));
        return new Size(tb.ActualWidth, tb.ActualHeight);
    }
