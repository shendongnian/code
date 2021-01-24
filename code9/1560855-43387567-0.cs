    /// <summary>
    /// MD5 of the data packet (i.e. MD5 of Content byte array)
    /// </summary>
    public string MD5 { get; private set; }
    
    private byte[] content;
    
    /// <summary>
    /// Byte content of the data packet (i.e. 
    /// </summary>
    public byte[] Content
    {
        get { return content; }
        set
        {
            content = value;
            UpdateMD5();
        }
    }
