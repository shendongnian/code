    public object Convert(object[] value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        if (value[0].GetType().Equals(typeof(ComboBox)) && value[1].GetType().Equals(typeof(String)))
        { 
            ComboBox boxVariable = value[0] as ComboBox;
            string textboxDec = value[1] as String;
            /* your method code here, returns Boolean */
        }
    }
