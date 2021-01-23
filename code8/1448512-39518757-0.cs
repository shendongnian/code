    var results = (from contact in constactList
                   group contact by contact.Name into contacts
                   select new Contact
                   {
                       Name = contacts.Key,
                       Fax = contact.FirstOrDefault(c => c.Fax != null)?.Fax,
                       Email = contact.FirstOrDefault(c => c.Email != null)?.Email 
                   }).ToList();
