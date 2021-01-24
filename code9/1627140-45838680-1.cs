    //Business
    public Client GetContact(Contact contact)
    {
        var dataAccess = new DataAccess();
        var client = dataAccess.ExecuteView(contact.FirstName, ...)
        //Do some business logic, if you want.
        return client;
    }
