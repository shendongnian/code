    public class IntegerToViewportConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var count = (int)value;
            var viewport = new Rect(0, 0, 0, 1);
            if (count > 0)
            {
                viewport.Width = 1 / (double)count;
            }
            return viewport;       
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
