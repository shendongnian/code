    public class TranslateExtension : MarkupExtension
    {
        public TranslateExtension(string text)
        {
            Text = text;
        }
        private static readonly LanguageConverter _converter = new LanguageConverter();
        public string Text { get; }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return _converter.Convert(Text, null, null, null);
        }
    }
