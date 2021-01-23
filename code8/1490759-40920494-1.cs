    private string _EncryptedPassword = null;
    public string EncryptedPassword 
    {
        get { return _EncryptedPassword ; }
        set { _EncryptedPassword = GetMd5Hash(value); }
    }
