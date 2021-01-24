    public class conv : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ProgressBar pb = value as ProgressBar;
            double av = pb.ActualWidth;
            double diff = pb.Maximum - pb.Minimum;
            return new GridLength((pb.Value / diff) * av);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
