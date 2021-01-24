    public class SyncConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
    
              if(value != null){
                bool? syncState = value as bool?;
    
                if (syncState != null) { 
                    if (syncState.Value) return "ic_success";
                    else return "ic_error";
                }
               }
              return "ic_idle";
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
