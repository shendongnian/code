    Dictionary<string, string> d = new Dictionary<string, string>();
    string[] attachmentPaths = Directory.GetFiles("c:\\temp");
    System.Security.Cryptography.SHA1Managed sha1 = new System.Security.Cryptography.SHA1Managed();
    byte[] oneFileHash = null;
    foreach (string attachment in attachmentPaths)
    {
        using (FileStream oneFileStream = File.OpenRead(attachment))
        {
            oneFileHash = sha1.ComputeHash(oneFileStream);
        }
        if (oneFileHash == null)
            continue;
        string base64EncodedHash = Convert.ToBase64String(oneFileHash);
        string attachmentFileName = Path.GetFileName(attachment);
        if (d.ContainsKey(base64EncodedHash))
        {
            Console.WriteLine("exists");
            //trying to get a value for a key that does not exist, on the first iteration, then the compiler jumps to the else{}
        }
        else
        {
            Console.WriteLine("!exists");
            //Since the <key, value> does not exist, go ahead and populate the dictionary
            d.Add(base64EncodedHash, attachmentFileName);
        }
    }
    foreach (KeyValuePair<string, string> pair in d)
    {
        Console.WriteLine("Key: " + pair.Key + " " + "Value: " + pair.Value);
    }
