    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        if (value.GetType().Equals(typeof(ComboBox)) && parameter.GetType().Equals(typeof(String)))
        { 
            ComboBox boxVariable = value as ComboBox;
            string textboxDec = parameter as String;
            /* your method code here, returns Boolean */
        }
    }
