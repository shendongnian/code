    foreach (string attachment in attachmentPaths)
    {
      //Base 64 conversion process
      attachmentBytes = File.ReadAllBytes(attachment);
      base64EncodedString = Convert.ToBase64String(attachmentBytes);
      attachmentFileName = Path.GetFileName(attachment);
      var filename=string.Empty;
    
      if (d.TryGetValue(base64EncodedString, out filename))
      {
        Console.WriteLine("exists");
        //trying to get a value for a key that does not exist, on the first iteration, then the compiler jumps to the else{}
      }
      else
      {
        Console.WriteLine("!exists");
        //Since the <key, value> does not exist, go ahead and populate the dictionary
        d.Add(base64EncodedString, attachmentFileName);
      }
    }
    
    //Print out the key value pair.
    //The value is not being printed.
    foreach (KeyValuePair<string, string> pair in d)
    {
      Console.WriteLine("Key: " + pair.Key + " " + "Value: " + pair.Value);
    }
