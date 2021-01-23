    string msg = "This is some text 123 1 87  45";
      
    string crypto = EncryptClass.EncryptString(msg, "I Like Pi");
    Console.WriteLine(crypto);
    string retVal = EncryptClass.DecryptString(crypto, "I Like Pi");
    Console.WriteLine(retVal);
