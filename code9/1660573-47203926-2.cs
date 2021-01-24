    public static void SetString(this ISession session, string key, string value)
    {
        session.Set(key, Encoding.UTF8.GetBytes(value));
    }
    public static string GetString(this ISession session, string key)
    {
        var data = session.Get(key);
        if (data == null)
        {
            return null;
        }
        return Encoding.UTF8.GetString(data);
    }
    public static byte[] Get(this ISession session, string key)
    {
        byte[] value = null;
        session.TryGetValue(key, out value);
        return value;
    }
