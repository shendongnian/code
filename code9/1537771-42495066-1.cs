    public class MyTextBlock : FrameworkElement
    {
        private FormattedText formattedText;
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(
                "Text", typeof(string), typeof(MyTextBlock),
                new FrameworkPropertyMetadata(
                    string.Empty,
                    FrameworkPropertyMetadataOptions.AffectsMeasure,
                    (o, e) => ((MyTextBlock)o).TextPropertyChanged((string)e.NewValue)));
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        private void TextPropertyChanged(string text)
        {
            var typeface = new Typeface(
                new FontFamily("Times New Roman"),
                FontStyles.Normal, FontWeights.Normal, FontStretches.Normal);
            formattedText = new FormattedText(
                text, CultureInfo.CurrentCulture,
                FlowDirection.LeftToRight, typeface, 15, Brushes.Black);
        }
        protected override Size MeasureOverride(Size availableSize)
        {
            return formattedText != null
                ? new Size(formattedText.Width, formattedText.Height)
                : new Size();
        }
        protected override void OnRender(DrawingContext drawingContext)
        {
            if (formattedText != null)
            {
                drawingContext.DrawText(formattedText, new Point());
            }
        }
    }
