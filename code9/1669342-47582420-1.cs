    public class PrintableFontFamilyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var fontFamily = value as FontFamily;
            if (fontFamily != null)
            {
                foreach (var typeface in fontFamily.GetTypefaces())
                {
                    if (typeface.TryGetGlyphTypeface(out var glyphTypeface))
                    {
                        if (glyphTypeface.Symbol)
                        {
                            return null;
                        }
                    }
                }
            }
            return fontFamily;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
