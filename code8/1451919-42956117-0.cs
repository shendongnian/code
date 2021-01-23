    private string longString;
    
    public bool IsCompressed { get; set; }
   
    public string LongString
    {
        get
        {
            return IsCompressed ? DeCompress(longString) : longString;
        }
        set
        {
           if (String.IsNullOrWhiteSpace(value) || value.Length < 64KB)
           {
               IsCompressed = false;
               longString = value;
           }
           else (value.Length > 64KB)
           {
               IsCompressed = true;
               longString = Compress(value);
           }
        }
    }
