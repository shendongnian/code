    public class CustomConverter : MarkupExtension, IMultiValueConverter
    {
        public CustomConverter()
        {
            Parameters = new List<Object>();
        }
        public List<Object> Parameters { get; set; }
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (Parameters == null)
                return Binding.DoNothing;
            //  Just something that returns something, for testing
            //  Replace with your own convertion logic. 
            return String.Join(";", Parameters);
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
