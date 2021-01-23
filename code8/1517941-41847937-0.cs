    using System;
    using System.Globalization;
    using System.Windows.Data;
    
    namespace P16_StepFunctions
    {
        /// <summary>
        /// Class for replacing comma by dot in input of decimal fields.
        /// </summary>
        public class DecimalConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                return value.ToString().Replace(",", ".");
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                return value.ToString().Replace(",", ".");
            }
    
        }
    }
