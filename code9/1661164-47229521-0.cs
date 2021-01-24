    string dir1 = ConfigurationManager.AppSettings.Get("FilePath");
    foreach(string aFile in Directory.EnumerateFiles(dir1))
    {
    	message.Attachments.Add(new Attachment(aFile));
    }
