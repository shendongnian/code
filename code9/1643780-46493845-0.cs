    public class ExEditor : Editor
    {
        public static readonly BindableProperty FormattedTextProperty =
            BindableProperty.Create(
                "FormattedText", typeof(FormattedString), typeof(ExEditor),
                defaultValue: default(FormattedString));
        public FormattedString FormattedText
        {
            get { return (FormattedString)GetValue(FormattedTextProperty); }
            set { SetValue(FormattedTextProperty, value); }
        }
        public ExEditor()
        {
            TextChanged += ExEditor_TextChanged;
        }
        void ExEditor_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Text))
                return;
            var pattern = @"\b(SELECT|WHERE|AND|OR)\b";
            var words = Regex.Split(Text, pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline);
            var formattedString = new FormattedString();
            foreach (var word in words)
                formattedString.Spans.Add(new Span
                {
                    Text = word,
                    BackgroundColor = BackgroundColor,
                    FontSize = FontSize,
                    FontFamily = FontFamily,
                    FontAttributes = FontAttributes,
                    ForegroundColor = Regex.IsMatch(word, pattern, RegexOptions.IgnoreCase) ? Color.Red : TextColor
                });
            FormattedText = formattedString; 
        }       
    }
