    public static bool TryParse(string s, out byte[] result)
    {
        result = null;
        // TODO: It's not clear why you don't want to be able to convert an empty string
        if (s == null || s.Length < 1)
        {
            return false;
        }
    
        byte buffer = new byte[s.Length + 1]; // Add space for null-terminator
        for (int i = 0; i < s.Length; i++)
        {
            char c = s[i];
            if (c > 127)
            {
                return false;
            }
            buffer[i] = (byte) c;
        }
        result = buffer;
        return true;
    }
