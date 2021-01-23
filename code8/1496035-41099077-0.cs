    private DateTime? _apiEndDate;
    internal DateTime? ApiEndDate
    {
        get { return _apiEndDate; }
        set
        {
            if (value == null)
                _apiEndDate = DateTime.MaxValue;
            else
            {
                _apiEndDate = value;
            }
        }
    }
    public DateTime EndDate => ApiEndDate ?? DateTime.MaxValue;
