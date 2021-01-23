     Addresses oAdrModel = new Addresses();
        oAdrModel.Address1 = "test xxx";
        oAdrModel.Address2 = "test xxx";
        oAdrModel.SerialNo = 3;
        oAdrModel.IsDefault = true;
        oAdrModel.CustomerID = 5;
        db.Addresses.Add(oAdrModel);
        int xx = oAdrModel.AddressID;
        Contacts ContactModel = new Contacts();
        ContactModel.Phone = "XX-1111111-33";
        ContactModel.Fax = "XX-1-1111111";
        ContactModel.SerialNo = 4;
        ContactModel.IsDefault = true;
        //ContactModel.AddressID = 5;
        ContactModel.Address = oAdrModel
        db.Contacts.Add(ContactModel);
        db.SaveChanges();
