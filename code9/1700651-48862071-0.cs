    var personWithHisContacts = myDbContext.Personels
        .Where(person => person.Id == id)
        .Select(person => new
        {
            // select only the Person properties you plan to use:
            Name = person.PersonelName,
            LastName = person.PersonelLastName,
            PrivateNo = person.PersonelPrivateNo,
            // I want all contacts of this Person:
            Contacts = person.Contacts
                .Select(contact => new
                {
                    // again: select only the properties you plan to use:
                    Id = contact.Id,
                    Value = contact.Value,
                    ContactTypeValue = contact.ContactType.Value,
                })
                .ToList(),
        });
