    public SerializableSecureString(string clearText)
    {
        if (clearText != null)
        {
            foreach (char t in clearText)
                Content.AppendChar(t);
        }
    }
