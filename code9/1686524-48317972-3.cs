    public class OutlinedText : FrameworkElement
    {
        private FormattedText text;
        public static readonly DependencyProperty TextProperty = TextBlock.TextProperty.AddOwner(
            typeof(OutlinedText), new FrameworkPropertyMetadata((o, e) => ((OutlinedText)o).text = null) { AffectsMeasure = true });
        public static readonly DependencyProperty TextAlignmentProperty = TextBlock.TextAlignmentProperty.AddOwner(
            typeof(OutlinedText), new FrameworkPropertyMetadata((o, e) => ((OutlinedText)o).text = null) { AffectsRender = true });
        public static readonly DependencyProperty FontSizeProperty = TextBlock.FontSizeProperty.AddOwner(
            typeof(OutlinedText), new FrameworkPropertyMetadata((o, e) => ((OutlinedText)o).text = null) { AffectsMeasure = true });
        public static readonly DependencyProperty FontFamilyProperty = TextBlock.FontFamilyProperty.AddOwner(
            typeof(OutlinedText), new FrameworkPropertyMetadata((o, e) => ((OutlinedText)o).text = null) { AffectsMeasure = true });
        public static readonly DependencyProperty FontStyleProperty = TextBlock.FontStyleProperty.AddOwner(
            typeof(OutlinedText), new FrameworkPropertyMetadata((o, e) => ((OutlinedText)o).text = null) { AffectsMeasure = true });
        public static readonly DependencyProperty FontWeightProperty = TextBlock.FontWeightProperty.AddOwner(
            typeof(OutlinedText), new FrameworkPropertyMetadata((o, e) => ((OutlinedText)o).text = null) { AffectsMeasure = true });
        public static readonly DependencyProperty FontStretchProperty = TextBlock.FontStretchProperty.AddOwner(
            typeof(OutlinedText), new FrameworkPropertyMetadata((o, e) => ((OutlinedText)o).text = null) { AffectsMeasure = true });
        public static readonly DependencyProperty ForegroundProperty = TextBlock.ForegroundProperty.AddOwner(
            typeof(OutlinedText), new FrameworkPropertyMetadata((o, e) => ((OutlinedText)o).text = null) { AffectsRender = true });
        public static readonly DependencyProperty BackgroundProperty = TextBlock.BackgroundProperty.AddOwner(
            typeof(OutlinedText), new FrameworkPropertyMetadata((o, e) => ((OutlinedText)o).text = null) { AffectsRender = true });
        public static readonly DependencyProperty OutlineBrushProperty = DependencyProperty.Register(
            nameof(OutlineBrush), typeof(Brush), typeof(OutlinedText),
            new FrameworkPropertyMetadata(Brushes.White, FrameworkPropertyMetadataOptions.AffectsRender, (o, e) => ((OutlinedText)o).text = null));
        public static readonly DependencyProperty OutlineThicknessProperty = DependencyProperty.Register(
            nameof(OutlineThickness), typeof(double), typeof(OutlinedText),
            new FrameworkPropertyMetadata(1d, FrameworkPropertyMetadataOptions.AffectsMeasure, (o, e) => ((OutlinedText)o).text = null));
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public TextAlignment TextAlignment
        {
            get { return (TextAlignment)GetValue(TextAlignmentProperty); }
            set { SetValue(TextAlignmentProperty, value); }
        }
        [TypeConverter(typeof(FontSizeConverter))]
        public double FontSize
        {
            get { return (double)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }
        public FontFamily FontFamily
        {
            get { return (FontFamily)GetValue(FontFamilyProperty); }
            set { SetValue(FontFamilyProperty, value); }
        }
        public FontStyle FontStyle
        {
            get { return (FontStyle)GetValue(FontStyleProperty); }
            set { SetValue(FontStyleProperty, value); }
        }
        public FontWeight FontWeight
        {
            get { return (FontWeight)GetValue(FontWeightProperty); }
            set { SetValue(FontWeightProperty, value); }
        }
        public FontStretch FontStretch
        {
            get { return (FontStretch)GetValue(FontStretchProperty); }
            set { SetValue(FontStretchProperty, value); }
        }
        public Brush Foreground
        {
            get { return (Brush)GetValue(ForegroundProperty); }
            set { SetValue(ForegroundProperty, value); }
        }
        public Brush Background
        {
            get { return (Brush)GetValue(BackgroundProperty); }
            set { SetValue(BackgroundProperty, value); }
        }
        public Brush OutlineBrush
        {
            get { return (Brush)GetValue(OutlineBrushProperty); }
            set { SetValue(OutlineBrushProperty, value); }
        }
        public double OutlineThickness
        {
            get { return (double)GetValue(OutlineThicknessProperty); }
            set { SetValue(OutlineThicknessProperty, value); }
        }
        protected override Size MeasureOverride(Size availableSize)
        {
            var size = CheckText() ? new Size(text.Width, text.Height) : new Size();
            if (!double.IsNaN(Width) && size.Width < Width)
            {
                size.Width = Width;
            }
            if (!double.IsNaN(Height) && size.Height < Height)
            {
                size.Height = Height;
            }
            return size;
        }
        protected override void OnRender(DrawingContext drawingContext)
        {
            if (CheckText())
            {
                var size = DesiredSize;
                var origin = new Point();
                if (size.Width > text.Width)
                {
                    if (TextAlignment == TextAlignment.Center)
                    {
                        origin.X = ((size.Width - text.Width) - OutlineThickness) / 2;
                    }
                    else if (TextAlignment == TextAlignment.Right)
                    {
                        origin.X = (size.Width - text.Width) - OutlineThickness;
                    }
                }
                if (size.Height > text.Height)
                {
                    origin.Y = (size.Height - text.Height) / 2;
                }
                if (Background != null)
                {
                    drawingContext.DrawRectangle(Background, null, new Rect(size));
                }
                drawingContext.DrawGeometry(Foreground, new Pen(OutlineBrush, OutlineThickness), text.BuildGeometry(origin));
            }
        }
        private bool CheckText()
        {
            if (text == null)
            {
                if (string.IsNullOrEmpty(Text))
                {
                    return false;
                }
                text = new FormattedText(
                    Text, CultureInfo.CurrentUICulture, FlowDirection.LeftToRight,
                    new Typeface(FontFamily, FontStyle, FontWeight, FontStretch),
                    FontSize, Brushes.Black);
            }
            return true;
        }
    }
