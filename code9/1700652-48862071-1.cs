    var personWithHisContacts = myDbContext.Personels // from all Persons
        .Where(person => person.Id == id)             // take the one with id
        .GroupJoin(myDbContext.Contacts               // GroupJoin with all Contacts
        person => person.Id,             // from each person take Id
        contact => contact.PersonelId,   // from each contact take PersonelId
        (person, contacts) => new        // when they match, make a new object
        {                                // containing only the properties you plan to use
            Name = person.PersonelName,
            LastName = person.PersonelLastName,
            PrivateNo = person.PersonelPrivateNo,
            // I want all contacts of this Person:
            Contacts = contacts.Select(contact => new
                {
                    // again: select only the properties you plan to use:
                    Id = contact.Id,
                    Value = contact.Value,
                    ContactTypeValue = contact.ContactType.Value,
                })
                .ToList(),
        });
