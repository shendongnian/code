    public static bool TryParse(string s, out byte[] result)
    {
        result = null;
        // TODO: It's not clear why you don't want to be able to convert an empty string
        if (s == null || s.Length < 1)
        {
            return false;
        }
    
        var fallback = new CustomFallback();
        var encoding = new ASCIIEncoding { EncoderFallback = fallback };
        byte buffer = new byte[s.Length + 1]; // Add space for null-terminator
        // Use overload of Encoding.GetBytes that writes straight into the buffer
        encoding.GetBytes(s, 0, s.Length, buffer, 0);
        if (fallback.HadErrors)
        {
            return false;
        }
        result = buffer;
        return true;
    }
    
