        using (var db = new TestDBContext())
        {
            var existingCustomer = db.Customer
            .Include(a => a.Addresses.Select(x=> x.Contacts))
            .FirstOrDefault(p => p.CustomerID == 5);
    
            existingCustomer.FirstName = "Test Customer122";
    
            foreach (var custaddress in existingCustomer.Addresses.Where(a => a.AddressID = 5))
            {
                //do stuff
            }
        }
