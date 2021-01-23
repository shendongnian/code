    public bool IsCompressed;
    public string StoredString { get; set; }
    private string longString;
    
    [IgnoreProperty] 
    public string LongString
    {
        get
        {
            if (this.longString == null)
            {
                if (IsCompressed)
                {
                    this.longString = DeCompress(StoredString);
                }
                else
                {
                    this.longString = StoredString;
                }
            }
            return this.longString;
        }
        set
        {
            if (longString != value)
            {
                this.longString = value;
                if (this.longString.Length > 64KB)
                {
                    IsCompressed = true;
                    this.StoredString = Compress(this.longString);
                }
            }
        }
    }
