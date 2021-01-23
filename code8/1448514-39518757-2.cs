    var results = constactList.GroupBy(contact => contact.Name)
        .Select(contacts => new Contact
        {
            Name = contacts.Key,
            Fax = contacts.FirstOrDefault(c => c.Fax != null)?.Fax,
            Email = contacts.FirstOrDefault(c => c.Email != null)?.Email 
        }).ToList();
