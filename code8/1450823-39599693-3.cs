    public async Task<List<LyncContact>> SearchAsync(string searchKey)
    {
	    List<LyncContact> contactList = new List<LyncContact>();
	    Console.WriteLine("Searching for contacts on " + searchKey);
	    var cm = LyncClient.GetClient().ContactManager;
    	var searchResults = await Task<SearchResults>.Factory.FromAsync<String>(
	    	cm.BeginSearch,
		    cm.EndSearch, searchKey, null);
    	if (searchResults.Contacts.Count > 0)
	    {
		    Console.WriteLine(searchResults.Contacts.Count.ToString() + " found");
    		foreach (Contact contact in searchResults.Contacts)
	    	{
		    	String displayName = contact.GetContactInformation(ContactInformationType.DisplayName).ToString();
		    	ContactAvailability currentAvailability = (ContactAvailability)contact.GetContactInformation(ContactInformationType.Availability);
			    Console.WriteLine(
    				 contact.GetContactInformation(ContactInformationType.DisplayName).ToString() + "   " + contact.GetContactInformation(ContactInformationType.Availability).ToString());
                LyncContact lyncContact = new LyncContact.Builder().DisplayName("Snehil").Availability("Busy").build();
                contactList.Add(lyncContact);
		    }
	    }
	
    	return contactList
    }
