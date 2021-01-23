      <MultiBinding Converter="{StaticResource TextAlternateConverter}">
    public class TextAlternateConverter: IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            
          StringBuilder myOutputText = new StringBuilder();
            foreach (string param in values)
            {
                if (param == "None")
                    myOutputText.Append("Give alternate text");
                else
                    myOutputText.Append(param);
            }
            return myOutputText.ToString();
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new System.NotImplementedException();
        }
    }
