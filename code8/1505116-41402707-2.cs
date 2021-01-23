    var customerSearchResult = customers.GroupBy(                               
                x => new {
                    x.CustomerID,
                    x.email,
                    x.CreatedOn,
                    x.FirstName,
                    x.LastName,
                    Profile = x.Profile == null ? -1 : x.Profile.Value
                })
                .Select(csr => new CustomerSearchResult
                {
                    CustomerID = csr.Key.CustomerID,
                    Email = csr.Key.email,
                    CreatedOn = csr.Key.CreatedOn
                });
