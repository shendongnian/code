    //Now simulate finding that contact, modify it, and save it
    var store = await ContactManager.RequestStoreAsync(ContactStoreAccessType.AppContactsReadWrite);
    
    var contacts = await store.FindContactsAsync("Test Contact");
    //This contact is a "aggregate contact"
    var contact = contacts[0];
    
    //Get the raw contacts according to the "aggregate contact"
    var allStore = await ContactManager.RequestStoreAsync(ContactStoreAccessType.AllContactsReadOnly);
    var rawContacts = await allStore.AggregateContactManager.FindRawContactsAsync(contact);
    
    foreach (var rawContact in rawContacts)
    {
        var contactList = await store.GetContactListAsync(rawContact.ContactListId);
    
        if (contactList != null && contactList.DisplayName == "Test List")
        {
            rawContact.Emails[0].Address = "newemail@test.com"; //Change a value
    
            await contactList.SaveContactAsync(rawContact);
            //await contactList.DeleteContactAsync(rawContact);
        }
    }
