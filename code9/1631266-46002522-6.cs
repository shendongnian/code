    public class TickConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var slider = (Slider)value;
            var tickOffsets = new List<double>();
            var sliderRange = (slider.Maximum - slider.Minimum);
            var tickcount = (int)Math.Floor(sliderRange / slider.TickFrequency);
            return Enumerable.Range(0, tickcount);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
