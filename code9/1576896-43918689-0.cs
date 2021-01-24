    var contacts = await Device.Contacts.GetAll();
    foreach (var contact in contacts)
    {
        if (contact.InstantMessagingAccounts.Any())
        {
            var connections = contact.InstantMessagingAccounts;
        }
    }
