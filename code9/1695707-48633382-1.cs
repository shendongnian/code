    DateTime parsedResult;
    string entry = "26 Feb";
    if(DateTime.TryParse(entry, new CultureInfo("en-AU"), DateTimeStyles.None, out parsedResult))
    {
        if (!entry.Contains(DateTime.Today.Year.ToString() &&
            !entry.Contains(DateTime.Today.ToString("yy"))
        {
            // This means the entry had no year
            DateTime advanced = parsedResult.AddYears(1);
        }
    }
