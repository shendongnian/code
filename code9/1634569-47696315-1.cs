     class AlternateColorConverter : IValueConverter
    {
        private static int idx_;
        private static int idx(int offset)
        {
                idx_ = ((idx_ + 1) % offset);
                return idx_;
        }
        public static Color GetColorFromHex(string hexString)
        {
            Color x = (Color)XamlBindingHelper.ConvertValue(typeof(Color), hexString);
            return x;
        }
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            int param = System.Convert.ToInt32(parameter);
            var acolor = (idx(param) % param == 0) ? new SolidColorBrush(ColorUtils.GetColorFromHex("#F24C27")) : new SolidColorBrush(ColorUtils.GetColorFromHex("#FBBA42"));
            return acolor;
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
