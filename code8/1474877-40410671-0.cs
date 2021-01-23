    public class FormattedTranslationExtension : TranslationExtension
    {
        public string Format { get; set; }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var baseValue = base.ProvideValue(serviceProvider)?.ToString();
            if (baseValue != null && Format != null)
                return string.Format(Format, baseValue);
            else
                return baseValue;
        }
    }
