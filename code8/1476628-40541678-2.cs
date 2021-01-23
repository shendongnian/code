    private void button3_Click(object sender, EventArgs e)
    {
        //Addresses CurrentAddress = null;
        //Contacts CurrentContacts = null;
        using (var db = new TestDBContext())
        {
            //db.Database.Log = s => MyLogger.Log("EFApp", s);
            var existingCustomer = db.Customer
            .Include(a => a.Addresses.Select(x => x.Contacts))
            .FirstOrDefault(p => p.CustomerID == 5);
            existingCustomer.FirstName = "New Customer";
            existingCustomer.Addresses.Where(a => a.AddressID == 5).ToList().ForEach(r => db.Addresses.Remove(r));
            existingCustomer.Addresses.Where(a => a.AddressID == 5).SelectMany(ad => ad.Contacts).Where(c=> c.ContactID==5).ToList().ForEach(r => db.Contacts.Remove(r));
            Addresses oAdrModel = new Addresses();
            oAdrModel.Address1 = "New test xxx";
            oAdrModel.Address2 = "New test xxx";
            oAdrModel.SerialNo = 3;
            oAdrModel.IsDefault = true;
            oAdrModel.Contacts = new List<Contacts>();
            //oAdrModel.CustomerID = 5;
            existingCustomer.Addresses.Add(oAdrModel);
            //db.Addresses.Add(oAdrModel);
            //db.SaveChanges();
            //int CurAddressID = oAdrModel.AddressID;
            Contacts ContactModel = new Contacts();
            ContactModel.Phone = "New XX-1111111-33";
            ContactModel.Fax = "New XX-1-1111111";
            ContactModel.SerialNo = 4;
            ContactModel.IsDefault = true;
            //ContactModel.Addresses = oAdrModel;
            oAdrModel.Contacts.Add(ContactModel);
            //ContactModel.AddressID = CurAddressID;
            //db.Contacts.Add(ContactModel);
            db.SaveChanges();
        }
    }
