    var clientsByID = listB.ToDictionary(c => c.ClientID);
    foreach(var clientA in listA)
    {
        var clientB = clientsByID[clientA.ClientID];
        clientA.DCCode = clientB.DCCode;
        clientA.CountryName = clientB.CountryName;
    }
