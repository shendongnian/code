    public Client GetContact(Contact contact)
    {
        var dataAccess = new DataAccess();
        var contactIdentifier = dataAccess.CreateContact(contact.FirstName, ...);
        var client = dataAccess.GetContact(contactIdentifier);
        //Do some business logic, if you want.
        return client;
    }
