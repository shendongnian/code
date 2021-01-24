    namespace WpfApplication1
    {
        public class RowHeightConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                DataGrid dg = value as DataGrid;
                if(dg != null && dg.Items.Count > 0)
                {
                    return dg.ActualHeight / dg.Items.Count;
                }
                return 20; //return some default height
            }
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotSupportedException();
            }
        }
    }
