    System.DirectoryServices.PropertyCollection coll = de.Properties;
    object obVal = coll["objectSid"].Value;
    string yourSID;
    if (null != obVal)
    {
        yourSID = ConvertByteToStringSid((Byte[])obVal);
    }
