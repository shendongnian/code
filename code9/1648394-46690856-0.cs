    private void Update(Contact contact, string[] fields)
    {
        contact.RecordId = fields[RecordIdIndex];
        contact.Salutation = fields[SalutationIndex];
        contact.firstName = fields[FirstNameIndex];
        contact.LastName = fields[LastNameIndex];
        contact.Organization = fields[OrganizationIndex];
        contact.Title = fields[TitleIndex];
        contact.Phone = fields[PhoneIndex];
        contact.Email = fields[EmailIndex];
        // Properties go here...
        return contact;
    };
    public void CreateOrUpdate()
    {
        if (!String.IsNullOrEmpty(contact.Email) && entities.Contacts.Any(a => a.Email.ToLower() == contact.Email.ToLower()))
        {
            // Contact already exists
            var dbcontact = entities.Contacts.FirstOrDefault(a => a.Email.ToLower() == contact.Email.ToLower());
            Update(dbcontact, fields);
            entities.Entry(dbcontact).State = EntityState.Modified;
        }
        else 
        {
            var contact = new Contact();
            Update(contact, fields);
            entities.Contacts.Add(contact);
        }
        entities.SaveChanges();
    }
