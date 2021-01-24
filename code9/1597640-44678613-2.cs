    private UserCredentials GetAddressBook(string userName)
    {
      int addressBookId = 0;
      bool valid = int.TryParse(userName, out addressBookId);
      if(!valid) 
      {
          var lastDigits = userName.SkipWhile(char.IsLetter).TakeWhile(char.IsDigit);
          valid = int.TryParse(string.Concat(lastDigits), out addressBookId);
      }
      if(valid)
          return this.GetAddressBook(addressBookId);  
      else
          return null;
    }
