    string longMessage = "";//The string to convert to bytes
    for (int i = 0; i < 1024; i++)//Adding 1024 chars
    {
        longMessage += "i";
    }
    byte[] buffer = Encoding.ASCII.GetBytes(longMessage);
