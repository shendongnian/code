    public static Boolean IsUtf8Encoding(Byte[] bytes)
    {
        UTF8Encoding enc = new UTF8Encoding(false, true);
        try { enc.GetString(bytes) }
        catch(ArgumentException) { return false; }
        return true;
    }
