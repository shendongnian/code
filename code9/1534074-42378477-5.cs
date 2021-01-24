    public class StringToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string color = (string)value;
            byte[] bytes = new byte[4];
            for (int i = 0; i < color.Length; i += 2)
                bytes[i / 2] = byte.Parse(color.Substring(i, 2), NumberStyles.HexNumber);
            return new SolidColorBrush(Color.FromArgb(bytes[0], bytes[1], bytes[2], bytes[3]));
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language) { throw new NotImplementedException(); }
    }
