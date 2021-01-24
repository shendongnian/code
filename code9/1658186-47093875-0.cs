    var listC = listA.Join(listB, 
                    a => a.ClientID, 
                    b => b.ClientID,
                    (a,b) => new Client { 
                       ClientID = a.ClientID, 
                       Name = a.Name,
                       DCCode = b.DCCode,
                       CountryName = b.CountryName
                    }).ToList();
