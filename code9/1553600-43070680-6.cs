    private string _serialNo;
    [RegularExpression(@"^[a-zA-Z0-9 ]+$", ErrorMessage = "Use letters and numbers only please")]
    [Display(Name = "Serial Number ")]
    public string SerialNo
    {
        get
        {
            return _serialNo;
        }
        set
        {
            _serialNo= value?.Trim();
        }
    }
