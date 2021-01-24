    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Data;
    
    namespace myProject
    {
        class UnixTimestampConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if (value != null)
                {
                    System.DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                    dateTime = dateTime.AddSeconds(System.Convert.ToDouble(value)).ToLocalTime();
                    return dateTime;
                }
                else
                {
                    return String.Empty;
                }
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                return value;
            }
        }
    }
