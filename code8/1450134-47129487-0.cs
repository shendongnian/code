    public DateTime? DateTimeTo { get; set; }
    public void ParseTo()
    {
        if(To.ToLower() == "null")
            DateTimeTo = null;
        else
            DateTimeTo = Convert.ToDateTime(To); 
    }
