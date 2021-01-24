    protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
    {
        base.OnPropertyChanged(e);
        if (e.Property == ForegroundProperty || e.Property == FloatColorProperty)
            UpdateTextBlock(); //updates the text-block inlines
    }
    protected override void OnTextChanged(TextChangedEventArgs e)
    {
        base.OnTextChanged(e);
        UpdateTextBlock(); // this can be merged to OnPropertyChanged (as text is also dependency property)
    }
    // new extracted method from OnTextChanged
    private void UpdateTextBlock()
    {
        if (MustShowValue())
        {
            // making sure text on TextBlock is updated as per TextBox
            var dotPos = Text.IndexOf('.');
            var textPart1 = dotPos == -1 ? Text : Text.Substring(0, dotPos + 1);
            var textPart2 = (dotPos == -1 || dotPos >= (Text.Length - 1)) ? null : Text.Substring(dotPos + 1);
            _textBlock.Inlines.Clear();
            _textBlock.Inlines.Add(new Run
            {
                Text = textPart1,
                FontFamily = FontFamily,
                FontSize = FontSize,
                Foreground = Foreground
            });
            if (textPart2 != null)
                _textBlock.Inlines.Add(new Run
                {
                    Text = textPart2,
                    FontFamily = FontFamily,
                    TextDecorations = System.Windows.TextDecorations.Underline,
                    BaselineAlignment = BaselineAlignment.TextTop,
                    FontSize = FontSize * 5 / 6,
                    Foreground = new SolidColorBrush(FloatColor)
                });
        }
    }
