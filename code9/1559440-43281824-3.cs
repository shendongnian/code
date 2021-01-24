    public class StringToColorConverter : IValueConverter
        {
    
            #region IValueConverter implementation
    
            public object Convert (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                if (value is string && value != null)  {
                    string s = (string)value;
                    switch(s){
                        case "A":
                            return Color.Red;
                        case "B":
                            return Color.Blue;
                        default:
                            return Color.Black
                    }
                    
                }
                return Color.Black;
            }
    
            public object ConvertBack (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException ();
            }
    
            #endregion
        }
