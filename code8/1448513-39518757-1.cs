    var results = (from contact in constactList
                   group contact by contact.Name into contacts
                   select new Contact
                   {
                       Name = contacts.Key,
                       Fax = contacts.FirstOrDefault(c => c.Fax != null)?.Fax,
                       Email = contacts.FirstOrDefault(c => c.Email != null)?.Email 
                   }).ToList();
