    // Provide reasonable default value
    private SodaDateTime _dteRegistered = 
        new SodaDateTime("DteRegistered", this, DateTime.Today);
    // Getter is a simple operation without preconditions
    public SodaDateTime DteRegistered
    {    
        get { return _dteRegistered; }
        set
        {            
            if (value == null) 
            { 
                throw new ArgumentOutOfRangeException("value cannot be null");
            }
 
            if (DateTimeUtil.IsNullDate(value)) 
            { 
                throw new ArgumentOutOfRangeException("value cannot have a null date"); 
                // or: value = DateTime.Today;
            }
            this._dteRegistered = DateTimeUtil.NullDateForMaxOrMinDate(
                new SodaDateTime("DteRegistered", this, value));
        }
    }
