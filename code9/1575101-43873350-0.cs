    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        try
        {
            // Formatierung bei Eingabefeldern
            if (value != null)
            {
                string inputStr = value.ToString();
                decimal inputDecimal = System.Convert.ToDecimal(value);
                if (inputStr.Contains(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator))
                {
                    return inputDecimal.ToString("F2");
                }
                else
                {
                    inputDecimal /= 100;
                    return inputDecimal.ToString("F");
                }
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Trace.WriteLine(
                String.Format("Error converting value {0}: {1}", value, ex.Message));
        }
        return null;
    }
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value;
    }
