    public class YesNoToBooleanConverter : IValueConverter
            {
                    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
                    {
                            switch(value.ToString().ToLower())
                            {
                                    case "yes":
                                    case "oui":
                                            return true;
                                    case "no":
                                    case "non":
                                            return false;
                            }
                            return false;
                    }
    
                    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
                    {
                            if(value is bool)
                            {
                                    if((bool)value == true)
                                            return "yes";
                                    else
                                            return "no";
                            }
                            return "no";
                    }
            }
