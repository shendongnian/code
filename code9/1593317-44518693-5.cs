    public string AttributeValuesSingleString
        (string attributeName, string objectDn)
    {
        string strValue;
        DirectoryEntry ent = new DirectoryEntry(objectDn);
        strValue = ent.Properties[attributeName].Value.ToString();
        ent.Close();
        ent.Dispose();
        return strValue;
    }
