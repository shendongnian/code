	public void AddingContact()
	{
		Contact addContact = new Contact();
		Console.WriteLine("Enter the name to be added:");
		addContact.Name = Console.ReadLine();
		string NewNumber;
		do 
		{
			NewNumber = Console.ReadLine();
			if (!IsValidPhoneNumber(NewNumber))
			{
				NewNumber = string.Empty;
			}
		} while (string.IsNullOrEmpty(NewNumber));
		Contact.PhoneNumber = NewNumber; // Or whatever the phone number field is
		ContactList.Add(Contact); // Or whatever the contact list is
	}
