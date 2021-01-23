    public sealed class GetStatiField: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            //value is a type of your TextBlock.DataContext
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
