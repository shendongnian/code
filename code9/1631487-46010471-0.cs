    string EncodeString(string str, Encoding encoding = null)
    {
        encoding = encoding ?? Encoding.UTF8;
        return Convert.ToBase64String(encoding.GetBytes(str));
    }
    string DecodeString(string str, Encoding encoding = null)
    {
        encoding = encoding ?? Encoding.UTF8;
        return encoding.GetString(Convert.FromBase64String(str));
    }
