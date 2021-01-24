    bool TryEncodingToASCII(string s, out byte[] result)
    {
        if (s == null || Regex.IsMatch(s, "[^\x00-\x7F]")) // If a single ASCII character is found, return false.
        {
            result = null;
            return false;
        }
        result = Encoding.ASCII.GetBytes(s); // Convert the string to ASCII bytes.
        return true;
    }
