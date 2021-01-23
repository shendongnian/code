    [ValueConversion(typeof(moWeek), typeof(vmWeek))]
    class MoWeekToVmWeekConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var moweek = value as moWeek;
            vmWeek result = //Do your conversion;
            return result;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (moWeek) value;
        }
    }
