    foreach (var CustContacts in existingAddress.Contacts.Where(a => a.ContactID == 5))
    {
        CurrentContacts = CustContacts;
        existingAddress.Contacts.Remove(CurrentContacts);
    }
