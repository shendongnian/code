    private static string Validate(string xml)
    {
        if (string.IsNullOrEmpty(xml))
            return xml;
    
        try
        {
            var index = xml.IndexOf('<');
            if (index > 0)
                xml = xml.Substring(index);
        }
        catch { }
    
        return xml;
    }
