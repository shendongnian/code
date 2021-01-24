    class NumberToBrushConverter : MarkupExtension, IValueConverter
    {
        private static NumberToBrushConverter _converter = null;
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            // determine if we have an instance of converter
            // return converter to client
            return _converter ?? (_converter = new NumberToBrushConverter());
        }
        public object Convert(object value, Type targetType,
                          object parameter,CultureInfo culture)
        {
            return new SolidColorBrush(Colors.Orange);
        }
        public object ConvertBack(object value, Type targetType, 
                              object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
      }  
