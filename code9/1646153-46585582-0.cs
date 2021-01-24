    public class ListToStringConverter : IValueConverter
        {
            #region IValueConverter implementation
            public object Convert (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                if (value!= null)  {
                   List<Object> temp = (List<Object>)value;
                   if(temp.Count == 0 )
                        return "";
                   string myString = "";
                   foreach(Object obj in temp){
                       myString += obj.Name + ",";
                  }
                  return myString;
                }
                return "";
            }
            public object ConvertBack (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException ();
            }
            #endregion
        }
