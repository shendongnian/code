    private void radDateTimePicker_ParseDateTimeValue(object sender, Telerik.Windows.Controls.ParseDateTimeEventArgs args)
    {
        DateTime date;
        string input = args.TextToParse.ToLower();
        CultureInfo provider = CultureInfo.InvariantCulture;
        string format = "dd/MM/yyyy";
        if (DateTime.TryParseExact(input, format, provider, DateTimeStyles.None, out date))
        {
            args.Result = date;
        }
        else
        {
            args.IsParsingSuccessful = false;
        }
    }
