    int ordinal = rdr.GetOrdinal("Country");
    if(rdr.IsDBNull(ordinal))
        inf.Country = Country.Undefined;
    else
    {
        if(!Enum.TryParse(rdr["Country"].ToString(), out inf.Country))
           inf.Country = Country.Undefined;
    }
