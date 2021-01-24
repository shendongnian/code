    ws.Url = "https://abc/ListingData.asmx";//Add this line
    ws.ListingData o = new ws.ListingData();
    ws.ListingAuthHeader h = new ws.ListingAuthHeader();
    h.Username = soapHeaderUsername;
    h.Password = soapHeaderPassword;
    o.ListingAuthHeaderValue = h;
    ds = o.GetListingData(countryId, maxListings);
