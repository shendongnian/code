    public class ContentTemplateConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var model = values[0] as ModelClass;
            var ctl = values[1] as FrameworkElement;
            switch (model.Foo)
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
