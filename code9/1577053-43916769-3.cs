    PrivateKeyFile privateKeyFile;
    using (Stream stream = File.OpenRead(@"C:\path\key"))
    using (StreamReader reader = new StreamReader(stream))
    using (MemoryStream tempStream = new MemoryStream())
    using (StreamWriter writer = new StreamWriter(tempStream))
    {
        string key = reader.ReadToEnd();
        Regex removeSubjectRegex = new Regex("Subject:.*[\r\n]+", RegexOptions.IgnoreCase);
        key = removeSubjectRegex.Replace(key, "");
        writer.Write(key);
        writer.Flush();
        tempStream.Position = 0;
        privateKeyFile = new PrivateKeyFile(tempStream);
    }
