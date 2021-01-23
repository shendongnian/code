    foreach (var CustContacts in existingAddress.Contacts.Where(a => a.ContactID == 5).ToList())
    {
        CurrentContacts = CustContacts;
        existingAddress.Contacts.Remove(CurrentContacts);
    }
