    public class TextAlignmentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var s = value as string;
            if (s == null) return TextAlignment.End;
            if (s.ToLower() == "me")
                return TextAlignment.Start;
            return TextAlignment.End;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
