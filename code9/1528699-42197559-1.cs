    public class PercentageConverter: IValueConverter
    { 
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            CollectionViewGroup cvg = value as CollectionViewGroup;
            int count = 0;
            int check = 0;
            foreach (Item t in cvg.Items)
            {
                count++;
                if (t.IsCheck== true)
                    check++;
            }
            return (check / (double)count).ToString("0.00") + "%";
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
