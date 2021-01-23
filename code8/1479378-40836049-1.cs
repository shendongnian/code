    PasswordCredential credential = null;
    if (!string.IsNullOrEmpty(line))
    {
        credential = new PasswordCredential()
        {
            Password = line
        };
    }
