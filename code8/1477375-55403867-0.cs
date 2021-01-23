    public bool? Public { get; set; }
    private bool _public;
    public bool _Public
    {
        get { return Public ?? false; }
        set 
        { 
          _public = value; 
          Public = value; 
        }
    }
