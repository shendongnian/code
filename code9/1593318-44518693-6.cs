    public static ArrayList GetUsedAttributes(string objectDn)
    {
        DirectoryEntry objRootDSE = new DirectoryEntry("LDAP://" + objectDn);
        ArrayList props = new ArrayList();
    
        foreach (string strAttrName in objRootDSE.Properties.PropertyNames)
        {
            props.Add(strAttrName);
        }
        return props;
    }
