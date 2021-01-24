    public string basic_decode(string key, string message)
    {
        List<char> decoded_chars = new List<char>();
        byte[] data = Convert.FromBase64String(message);
        string decodedString = Encoding.UTF8.GetString(data);
        data = Convert.FromBase64String(decodedString);
        foreach (int i in Enumerable.Range(0, data.Length))
        {
            char key_c = key[i % key.Length];
            char encoded_c = (char)Math.Abs((int)data[i] - (int)key_c % 256); 
            decoded_chars.Add(encoded_c);
        }
        string decoded_string = string.Join("", decoded_chars);
        return decoded_string;
    }
