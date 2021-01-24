    namespace SampleFormsApp {
    public class DisplayNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
          object parameter, CultureInfo culture)
        {
            if (value == null || targetType != typeof(string))
                return null;
            var propertyName = parameter as string;
            if (propertyName == null)
                return null;
            var propertyInfo = value.GetType().GetTypeInfo().DeclaredMembers
              .SingleOrDefault(m => m.Name == propertyName);
            if (propertyInfo == null)
                return null;
            return propertyInfo.GetCustomAttribute<DisplayAttribute>().Name;
        }
        public object ConvertBack(object value, Type targetType,
          object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
