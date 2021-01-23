    var contactList = new List<Contact> {
    	new Contact { Name="a", Fax = "1", Email=""},
    	new Contact { Name="b", Fax = "", Email="b@email.com"},
    	new Contact { Name="c", Fax = "3", Email="c@email.com"},
    	new Contact { Name="a", Fax = "", Email="a@email.com"},
    	new Contact { Name="b", Fax = "2", Email=""},
    
    };
    
    var result = (from c in contactList
    				.Where(contact => !string.IsNullOrEmpty(contact.Name))
    				.Select(c => c.Name)
    				.Distinct()
    			 let fax = contactList.FirstOrDefault(contact => contact.Name == c &&
    					 !string.IsNullOrEmpty(contact.Fax))
    			 let email = contactList.FirstOrDefault(contact => contact.Name == c &&
    					 !string.IsNullOrEmpty(contact.Email))
    			 select new Contact {
    				 Name = c,
    				 Fax = fax == null ? "" : fax.Fax,
    				 Email = email == null ? "" : email.Email
    			 })
    			 .ToList();
