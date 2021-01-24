    protected override SizeRequest OnMeasure(double widthConstraint, double heightConstraint)
    {
        _button.HorizontalOptions = (Parent as View).HorizontalOptions;
        _button.VerticalOptions = (Parent as View).VerticalOptions;
        var width = 0d;
        if (_button.Text != null)
        {
            var size = DependencyService.Get<ITextMeter>().MeasureTextSize(_button.Text.TrimEnd(), 200, _button.FontSize);
            width = size.Width + 40 + _button.Height;
        }
        return base.OnMeasure(width, heightConstraint);
    }
