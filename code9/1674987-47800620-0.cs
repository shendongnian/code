    public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        double totalWidth = 0;
        foreach (double Width in values.OfType<double>())
            totalWidth += Width;
        DataGridLength outLen = new DataGridLength(totalWidth);
        return outLen;
    }
