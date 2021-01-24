    public enum TeaType
    {
        Hot, Cold
    }
    class TeaTypeButtonStyleConverter : IValueConverter
    {
        public Style HotStateStyle { get; set; }
        public Style ColdStateStyle { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            TeaType teaType = (TeaType)value;
            if (teaType == TeaType.Hot)
            {
                return HotStateStyle;
            }
            else if (teaType == TeaType.Cold)
            {
                return ColdStateStyle;
            }
            return null;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
