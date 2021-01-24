    foreach (var c1 in Clients1)
    {
        var c2 = Clients2.FirstOrDefault(i => i.ClientID == c1.ClientID);
        if(c2 != null)
        {
            c1.DCCode = c2.DCCode;
            c1.CountryName = c2.CountryName;
        }
    }
