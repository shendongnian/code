     public static string Base64Encode(string key)
     {
        var value = System.Text.Encoding.UTF8.GetBytes(key);
        return System.Convert.ToBase64String(value);
     }
