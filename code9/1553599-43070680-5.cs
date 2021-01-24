    private string _serialNo;
    [RegularExpression(@"^[a-zA-Z0-9 ]+$", ErrorMessage = "Use letters and numbers only please")]
    [Display(Name = "Serial Number ")]
    public string SerialNo
    {
        get
        {
            try
            {
                _serialNo= _serialNo.Trim();
                return _serialNo;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return _serialNo;
            }
        }
        set
        {
            _serialNo= value;
        }
    }
