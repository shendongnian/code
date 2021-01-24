    // Required namespace: using Nager.Date;
    DateTime date = DateTime.Today;
    string strCountryIdentifier = "US";
    if (DateSystem.IsPublicHoliday(date, strCountryIdentifier)) 
    {
        // Do something here
    }
