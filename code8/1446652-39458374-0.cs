    public class SumValues : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var cvg = value as CollectionViewGroup;
            var field = parameter as string;
            if (cvg == null || field == null)
                return null;
    
            // Double field
            return cvg.Items.Sum(r => (double)(r as DataRowView)[field]);
            // Or, if the field is nullable
            //return cvg.Items.Sum(r => (r as DataRowView)[field] as double?); // "as" can return null so we have to use "double?"
    
            // More complex example - string field that needs to be converted to a long
            //return cvg.Items.Sum(r => long.Parse((r as DataRowView)[field].ToString()));
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
