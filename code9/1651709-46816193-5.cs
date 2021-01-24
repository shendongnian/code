    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is string)
        {
            DateTime parsedDate = DateTime.MinValue;
            if (DateTime.TryParse(value.ToString(), null, DateTimeStyles.RoundtripKind, out parsedDate))
            {
                return string.Format("{0:MM/dd/yyyy}", parsedDate);
            }
        }
        return string.Empty;
    }
