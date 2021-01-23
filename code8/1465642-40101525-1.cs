    DirectoryEntry directoryEntry = new DirectoryEntry(path);
    if (user == "" && password == "")
    {
        directoryEntry.Username = user;
        directoryEntry.Password = password;
    }
