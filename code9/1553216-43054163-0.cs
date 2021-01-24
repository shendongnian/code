    private string _startMonth;
    
    [Column("STARTMONTH")]
    public string StartMonth
    {
        get
        {
            if (string.IsNullOrWhiteSpace(_startMonth) && StartDate.HasValue)
                return StartDate.Value.ToString("MMMM");
            return _startMonth;
        }
        set { _startMonth = value; }
    }
