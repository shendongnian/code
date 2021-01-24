    public void SaveFile(StreamWriter writer)
    {
        AddressBook encryptedBook = New AddressBook();
    
        foreach (var item in ls.Contacts)
        {
            var encryptedContact = new Contact
        	{
            	Question1 = XMLEncryption.Model.Helpers.Encryptor.Encrypt(item.Question1),
            	Question2 = XMLEncryption.Model.Helpers.Encryptor.Encrypt(item.Question2),
            	Question3 = XMLEncryption.Model.Helpers.Encryptor.Encrypt(item.Question3)
        	};
    
            encryptedBook.Contacts.Add(encryptedContact);
        }
    
        xs.Serialize(writer, encryptedBook);
        MessageBox.Show("File saved... ");
    }
