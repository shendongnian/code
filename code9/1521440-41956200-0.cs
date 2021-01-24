    private DateTime _effectiveDate;
    ...
    public DateTime DateOfEffectiveDate
    {
        get { return _effectiveDate; }
        set
        {
            _effectiveDate = new DateTime(value.Year, value.Month, value.Day, _effectiveDate.Hour, _effectiveDate.Minute, _effectiveDate.Second);
        }
    }
    
    public DateTime TimeOfEffectiveDate
    {
        get { return _effectiveDate; }
        set
        {
            _effectiveDate = new DateTime(_effectiveDate.Year, _effectiveDate.Month, _effectiveDate.Day, value.Hour, value.Minute, value.Second);
        }
    }
