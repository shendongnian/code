    public class TransactionTypeConverter: IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                var trxnType = value as int;
                if (value == null || trxnType==null) return Brushes.Transparent;
    
                if(trxnType==1) return Brushes.Red;            
                return Brushes.Transparent;
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {        
    }               
        
