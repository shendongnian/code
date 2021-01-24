    string[] values = lines1[i].Split(',');
    if (values.Length >= 3)
    {
        DateTime dt;
        if (DateTime.TryParseExact(values[0], "d-MMM-yyyy", 
            System.Globalization.CultureInfo.CurrentCulture, 
            System.Globalization.DateTimeStyles.None, out dt))
        {
            values[0] = dt.ToString("yyyy-MM-dd");
            lines1[i] = String.Join(",", values);
        }
    }
