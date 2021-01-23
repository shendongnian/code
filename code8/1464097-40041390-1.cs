    private string implementationEndString = DataTimeExtensions.NullableDateTimeToString(Implementation_End);
    public string Implementation_End_String 
    {
        get{ return implementationEndString; }
        set{ implementationEndString=value; }
        //if you don't want this property to be not changed, just remove the setter.
    }
