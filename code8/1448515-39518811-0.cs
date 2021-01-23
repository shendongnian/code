    var dict = new Dictionary<string, Contact>();
    foreach (var contact in contactList)
    {
    	Contact existingContact;
    	if (dict.TryGetValue(contact.Name, out existingContact))
    	{
    		if (String.IsNullOrEmpty(existingContact.Fax))
    			existingContact.Fax = contact.Fax;
    		if (String.IsNullOrEmpty(existingContact.Email))
    			existingContact.Email = contact.Email;
    	}
    	else
    	{
    		dict.Add(contact.Name, contact);
    	}
    }
    var list = dict.Values.ToList();
