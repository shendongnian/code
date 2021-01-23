    public class TranslateExtension : MarkupExtension
    {
        public TranslateExtension(string text)
        {
            Text = text;
        }
        public string Text { get; }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var binding = new Binding
            {
                Mode = BindingMode.OneWay,
                Path = new PropertyPath($"[{Text}]"),
                Source = Translator.Instance,
            };
            return binding.ProvideValue(serviceProvider);
        }
    }
