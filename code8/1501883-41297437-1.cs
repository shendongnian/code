        public class MyBkColorConverter2 : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                DataRowView drv = value as DataRowView;
                if (drv != null)
                {
                    int rownum = drv.Row.Table.Rows.IndexOf(drv.Row);
                    if (rownum == 1)
                    {
                        return Brushes.Yellow;
                    }
                }
                return Brushes.White;
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
