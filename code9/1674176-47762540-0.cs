    public class ExampleConverter : MarkupExtension, IValueConverter
    {
        public ExampleConverter()
        {
        }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
        #region IValueConverter Members
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if(value != null && value is Gem)
				return (value as Gem).GemAsText();
			return value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }
        #endregion
    }
