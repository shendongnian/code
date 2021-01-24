    [ContentProperty(nameof(Text))]
    public class MyTextControl : FrameworkElement
    {
        // I have only declared Text as a dependency property, but fonts, etc should be here
        public static DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(MyTextControl),
            new FrameworkPropertyMetadata(string.Empty,
                FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.AffectsMeasure));
        private List<TextLine> _lines = new List<TextLine>();
        private TextFormatter _formatter = TextFormatter.Create();
        public string Text { get => ((string)GetValue(TextProperty)); set { SetValue(TextProperty, value); } }
        protected override Size MeasureOverride(Size availableSize)
        {
            // dispose old stuff
            _lines.ForEach(l => l.Dispose());
            _lines.Clear();
            double height = 0;
            double width = 0;
            var ts = new MyTextSource(Text);
            var index = 0;
            double maxWidth = availableSize.Width;
            if (double.IsInfinity(maxWidth))
            {
                // it means width was not fixed by any constraint above this.
                // we pick an arbitrary value, we could use visual parent, etc.
                maxWidth = 100;
            }
            double firstWordWidth = 0; // will be computed with the 1st line
            while (index < Text.Length)
            {
                // we indent the second line
                var props = new MyTextParagraphProperties(new MyTextRunProperties(), _lines.Count == 1 ? firstWordWidth : 0);
                var line = _formatter.FormatLine(ts, index, maxWidth, props, null);
                if (_lines.Count == 0)
                {
                    // get first word and whitespace real width (so we can support justification / whitespaces widening, kerning)
                    firstWordWidth = line.GetDistanceFromCharacterHit(new CharacterHit(ts.FirstWordAndSpaces.Length, 0));
                }
                index += line.Length;
                _lines.Add(line);
                height += line.TextHeight;
                width = Math.Max(width, line.WidthIncludingTrailingWhitespace);
            }
            return new Size(width, height);
        }
        protected override void OnRender(DrawingContext dc)
        {
            double height = 0;
            for (int i = 0; i < _lines.Count; i++)
            {
                if (i == _lines.Count - 1)
                {
                    // last line centered (using pixels, not characters)
                    _lines[i].Draw(dc, new Point((RenderSize.Width - _lines[i].Width) / 2, height), InvertAxes.None);
                }
                else
                {
                    _lines[i].Draw(dc, new Point(0, height), InvertAxes.None);
                }
                height += _lines[i].TextHeight;
            }
        }
    }
    // this is a simple text source, it just gives back one set of characters for the whole string
    public class MyTextSource : TextSource
    {
        public MyTextSource(string text)
        {
            Text = text;
        }
        public string Text { get; }
        public string FirstWordAndSpaces
        {
            get
            {
                if (Text == null)
                    return null;
                int pos = Text.IndexOf(' ');
                if (pos < 0)
                    return Text;
                while (pos < Text.Length && Text[pos] == ' ')
                {
                    pos++;
                }
                return Text.Substring(0, pos);
            }
        }
        public override TextRun GetTextRun(int index)
        {
            if (Text == null || index >= Text.Length)
                return new TextEndOfParagraph(1);
            return new TextCharacters(
               Text,
               index,
               Text.Length - index,
               new MyTextRunProperties());
        }
        public override TextSpan<CultureSpecificCharacterBufferRange> GetPrecedingText(int indexLimit) => throw new NotImplementedException();
        public override int GetTextEffectCharacterIndexFromTextSourceCharacterIndex(int index) => throw new NotImplementedException();
    }
    public class MyTextParagraphProperties : TextParagraphProperties
    {
        public MyTextParagraphProperties(TextRunProperties defaultTextRunProperties, double indent)
        {
            DefaultTextRunProperties = defaultTextRunProperties;
            Indent = indent;
        }
        // TODO: some of these should be DependencyProperties on the control
        public override FlowDirection FlowDirection => FlowDirection.LeftToRight;
        public override TextAlignment TextAlignment => TextAlignment.Justify;
        public override double LineHeight => 0;
        public override bool FirstLineInParagraph => true;
        public override TextRunProperties DefaultTextRunProperties { get; }
        public override TextWrapping TextWrapping => TextWrapping.Wrap;
        public override TextMarkerProperties TextMarkerProperties => null;
        public override double Indent { get; }
    }
    public class MyTextRunProperties : TextRunProperties
    {
        // TODO: some of these should be DependencyProperties on the control
        public override Typeface Typeface => new Typeface("Segoe UI");
        public override double FontRenderingEmSize => 20;
        public override Brush ForegroundBrush => Brushes.Black;
        public override Brush BackgroundBrush => Brushes.White;
        public override double FontHintingEmSize => FontRenderingEmSize;
        public override TextDecorationCollection TextDecorations => new TextDecorationCollection();
        public override CultureInfo CultureInfo => CultureInfo.CurrentCulture;
        public override TextEffectCollection TextEffects => new TextEffectCollection();
    }
