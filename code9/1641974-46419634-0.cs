    // Example strings
    var myDate1AsString = "31/12/2016";
    var myDate2AsString = "31-dec-2016";
    // DateTime object used to retrieved the dates as string
    var myDate1AsDate = new DateTime();
    var myDate2AsDate = new DateTime();
    // Parse the strings; if the parse fail, the date is set to DateTime.MinValue
    DateTime.TryParseExact(myDate1AsString, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out myDate1AsDate);
    DateTime.TryParseExact(myDate2AsString, "dd-MMM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out myDate2AsDate);
    // Correctly compare the dates
    var result = DateTime.Compare(myDate1AsDate, myDate2AsDate);
    
    // or, directly compare a date with the other.
    if (!myDate1AsDate.Equals(myDate2AsDate))
    {
        // Do some stuff.
    }
