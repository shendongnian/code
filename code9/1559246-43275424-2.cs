        public class ModeToTemplateConverter : IValueConverter
        {
            public DataTemplate ATemplate { get; set; }
            public DataTemplate BTemplate { get; set; }
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                var mode = value as Mode?;
                switch (mode)
                {
                    case Mode.A:
                        return ATemplate;
                    case Mode.B:
                        return BTemplate;
                    default:
                        return null;
                }
            }
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
