    int ordinal = rdr.GetOrdinal("Country");
    // Check for null value....
    if(rdr.IsDBNull(ordinal))
        inf.Country = Country.Undefined;
    else
    {
        // OK, not null, but what if it is "ABC"??
        if(!Enum.TryParse(rdr["Country"].ToString(), out inf.Country))
           inf.Country = Country.Undefined;
        // OK, but what if it is a number not defined in the coutry enum (IE "88")
        if(!Enum.IsDefined(typeof(Country), inf.Country))
           inf.Country = Country.Undefined;
    }
