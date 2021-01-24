    public class IsCheckedConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool isChecked = (bool)values[0];
            MyModel myModel = (MyModel)values[1];
            if (isChecked == true)
            {
                return myModel.ListA;
            }
            else
            {
                return myModel.ListB;
            }
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }  
    }
