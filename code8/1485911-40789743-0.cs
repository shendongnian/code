    public sealed class LocalizeConverter : IValueConverter
    {
        private static readonly ResourceLoader Loader = ResourceLoader.GetForViewIndependentUse("/Resources");
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string resourceId = parameter as string;
            return !string.IsNullOrEmpty(resourceId) ? Loader.GetString(resourceId) : DependencyProperty.UnsetValue;
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotSupportedException();
        }
    }
