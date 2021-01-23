        // German date dd.mm.yyyy
        string dateString = "01.03.2016";
        CultureInfo fromCulture = new CultureInfo("en-US");
        DateTime tryParseDateTime;
        // expecting result to fail
        if (DateTime.TryParseExact(dateString, fromCulture.DateTimeFormat.ShortDatePattern, fromCulture, DateTimeStyles.None, out tryParseDateTime))
        {
            MessageBox.Show("Success");
        }
        else
        {
            MessageBox.Show("Failed");
        }
