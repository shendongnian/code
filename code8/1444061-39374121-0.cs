     var bsCustomer1 = db.Customer.Where(p => p.CustomerID == 2)
            .Select(x => new CustomerBase
            {
                CustomerID = x.CustomerID,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Address1 = x.Addresses.First(a => a.IsDefault).Address1,
                Address2 = x.Addresses.First(a => a.IsDefault).Address2,
                Phone = x.Addresses.First(a => a.IsDefault).Contacts.First(c => c.IsDefault).Phone),
                Fax = x.Addresses.First(a => a.IsDefault).Contacts.First(c => c.IsDefault).Fax)
            }).ToList();
