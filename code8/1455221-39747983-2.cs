    public string IT_Date_String 
    { 
        get
        {
            return IT_Date.HasValue ? IT_Date.Value.ToString(...) : "";
        }
    }
