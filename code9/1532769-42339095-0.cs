    private string _Phone; 
    public string Phone
    {
        get { return _Phone; }
        set
        {    // VS says that StackOverflowException happens here
            if (value.Length == 10)
            {
                _Phone = value;
            }
            else
            {
                _Phone = "0000000000";
            }
        }
    }
