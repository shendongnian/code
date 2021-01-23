        using (var db = new TestDBContext())
        {
            var customer = new Customer
            {
                FirstName = "Test Customer1",
                LastName = "Test Customer1",
            };
            db.Customer.Add(customer);
            db.SaveChanges();
            int CustomerID = customer.CustomerID;
            Addresses oAdr = new Addresses();
            oAdr.Address1 = "test add1";
            oAdr.Address2 = "test add2";
            oAdr.IsDefault = true;
            oAdr.CustomerID = CustomerID;
            oAdr.SerialNo = 1;
            db.Addresses.Add(oAdr);
            db.SaveChanges();
            int AddressID = oAdr.AddressID;
            Contacts oContacts = new Contacts();
            oContacts.Phone = "1111111";
            oContacts.Fax = "1-1111111";
            oContacts.SerialNo = 1;
            oContacts.IsDefault = true;
            oContacts.AddressID = AddressID;
            db.Contacts.Add(oContacts);
            db.SaveChanges();
            oContacts = new Contacts();
            oContacts.Phone = "222222222";
            oContacts.Fax = "2-1111111";
            oContacts.SerialNo = 2;
            oContacts.IsDefault = false;
            oContacts.AddressID = AddressID;
            db.Contacts.Add(oContacts);
            db.SaveChanges();
            oAdr = new Addresses();
            oAdr.Address1 = "test add3";
            oAdr.Address2 = "test add3";
            oAdr.SerialNo = 2;
            oAdr.IsDefault = false;
            oAdr.CustomerID = CustomerID;
            db.Addresses.Add(oAdr);
            db.SaveChanges();
            AddressID = oAdr.AddressID;
            oContacts = new Contacts();
            oContacts.Phone = "33333333";
            oContacts.Fax = "3-1111111";
            oContacts.IsDefault = true;
            oContacts.SerialNo = 1;
            oContacts.AddressID = AddressID;
            db.Contacts.Add(oContacts);
            db.SaveChanges();
            oContacts = new Contacts();
            oContacts.Phone = "444444444";
            oContacts.Fax = "4-1111111";
            oContacts.SerialNo = 2;
            oContacts.IsDefault = false;
            oContacts.AddressID = AddressID;
            db.Contacts.Add(oContacts);
            db.SaveChanges();
        }
