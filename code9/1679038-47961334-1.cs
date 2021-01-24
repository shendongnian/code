    private Double ignoreCommission;
    private Double includeCommissionAndDiv;
    
    public Double IgnoreCommission
    {
        get
        {
            return this.ignoreCommission;    <-- set conditional breakpoint here
        }
        set
        {
            this.ignoreCommission = value;   <-- set conditional breakpoint here
        }
    }
    public Double IncludeCommissionAndDiv
    {
        get
        {
            return this.includeCommissionAndDiv;    <-- set conditional breakpoint here
        }
        set
        {
            this.includeCommissionAndDiv = value;   <-- set conditional breakpoint here
        }
    }
