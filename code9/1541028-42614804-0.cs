    public static string Parse(string xml, string tag, bool clean, bool replaceNewLines)
    {
       xml = xml.Replace("\r", "").Replace("\n", " ");
       ...
     
    }
