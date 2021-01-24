    public class ContentTemplateConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var ctl = values[1] as FrameworkElement;
            switch ($"{values[0]}")
            {
                case "foo":
                    return ctl.FindResource("Foo") as DataTemplate;
                case "bar":
                    return ctl.FindResource("Bar") as DataTemplate;
            }
            return null;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
