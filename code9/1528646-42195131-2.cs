    public class HeaderConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            ObservableCollection<Article> list = values[0] as ObservableCollection<Article>;
            Article obj = values[1] as Article;
            int ind = list.IndexOf(obj);
            if (ind == -1)
                return "+";
            else
                return (ind + 1).ToString();
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
