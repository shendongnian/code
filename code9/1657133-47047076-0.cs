    using (var context = new DBEntities())
    {
      // A better way to select the ID rather than returning the entire entity:
      var creatorID = context.UserProfiles
        .Where(up =>  up.Contact.FirstName == "automationtestuser")
        .Select(up => up.ID)
        .SingleOrDefault();
    
      foreach (var item in data)
      {
        var contact = new Contact
        {
          //contact.ID = Guid.NewGuid(), Definitely recommend letting DB generate ID using NewSequentialId.
          FirstName = item.FirstName,
          LastName = item.LastName,
          CreationDate = DateTime.Now,
          CreatedBy = creatorID,
    
          PhoneNumber = new PhoneNumber 
          {
            CreatedBy = creatorID;
            CreationDate = DateTime.Now;
            TypeID = (int)PhoneNumberTypes.Office;
            Number = item.PhoneNumber;
            CountryID = item.CountryID;
          }
        }
        context.Contacts.Add(contact);
        context.SaveChanges(); 
      }
    }
