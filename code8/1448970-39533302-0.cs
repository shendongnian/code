    public class IndexToNumberConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int index = Convert.ToInt32(value);
            switch(index)
            {
                case 0:
                    return "ZERO";
                case 10:
                    return "TEN";
                default:
                    return "OTHER";
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string val = value.ToString();
            switch(val)
            {
                case "ZERO":
                    return 0;
                case "TEN":
                    return 10;
                default:
                    return -1;
            }
        }
    }
