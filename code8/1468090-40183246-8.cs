    public class EdgeItemMargin : MarkupExtension, IValueConverter
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
        public object Convert(
            object value, 
            Type targetType, 
            object parameter, 
            CultureInfo culture)
        {
            var edge = (EdgeItem)value;
            return new Thickness(
                Math.Min(edge.V1.X, edge.V2.X), 
                Math.Min(edge.V1.Y, edge.V2.Y), 
                0, 0);
        }
        public object ConvertBack(
            object value, 
            Type targetType, 
            object parameter, 
            CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
