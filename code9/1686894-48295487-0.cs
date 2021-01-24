    public static string ObscureJson(string json)
    {
        if (json == null) return null;
        JToken token = JToken.Parse(json);
        using (HashAlgorithm hashAlgo = new SHA1Managed())
        {
            JContainer container = token as JContainer;
            if (container != null)
            {
                foreach (JValue value in container.Descendants().OfType<JValue>().ToList())
                {
                    value.Replace(HashJValue(value, hashAlgo));
                }
            }
            else
            {
                token = HashJValue((JValue)token, hashAlgo);
            }
            return token.ToString();    
        }
    }
    public static JValue HashJValue(JValue val, HashAlgorithm hashAlgo)
    {
        if (val == null || val.Type == JTokenType.Null) return val;
        byte[] buffer = Encoding.UTF8.GetBytes(val.ToString());
        byte[] hash = hashAlgo.ComputeHash(buffer);
        string hex = string.Join("", hash.Select(b => b.ToString("X2")));
        return new JValue(hex);
    }
