    public class TickConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var slider = (Slider)values[0];
            //  Must be bound separately so we get invoked again when its value changes. 
            //  Could separately bind all the other properties of the Slider, and I may 
            //  deservedly take some flak for not doing so, but I got lazy. 
            var actualWidth = (double)values[1];
            var tickOffsets = new List<double>();
            var sliderRange = (slider.Maximum - slider.Minimum);
            var scaleFactor = actualWidth / sliderRange;
            for (double tick = 0; tick <= sliderRange; tick += (float)slider.TickFrequency)
            {
                tickOffsets.Add(tick * scaleFactor);
            }
            return tickOffsets;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
