    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Data;
    using System.Windows.Media;
    
    namespace StackOverflowBinding
    {
        
        [ValueConversion(typeof(double), typeof(Brush))]
        public class AverageExecutionTimeToColorConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                double val;
                double.TryParse(value.ToString(), out val);
    
                if (val >= 10000)
                {
                    return Brushes.Red;
                }
                else if (val >= 5000)
                {
                    return Brushes.Orange;
                }
                else
                {
                    return Brushes.Green;
                }
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    
        [ValueConversion(typeof(int), typeof(Brush))]
        public class ThreadsAvailableCountToColorConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                int val;
                int.TryParse(value.ToString(), out val);
    
                if (val < 100)
                {
                    return Brushes.Red;
                }
                else if (val < 200)
                {
                    return Brushes.Orange;
                }
                else if (val < 500)
                {
                    return Brushes.Yellow;
                }
                else
                {
                    return Brushes.Green;
                }
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
