    /// <summary>
    /// Permit {local:TemplateConverter} markup
    /// </summary>
    public class TemplateConverterExtension : MarkupExtension
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
            => new TemplateConverter();
    }
    public class TemplateConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length >= 1 && values[0] is string template)
            {
                return string.Format(template, values.Skip(1).ToArray());
            }
            throw new ArgumentException("Give at least a template");
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
            => throw new NotImplementedException("Todo, eventually");
    }
