    private string _phone;
    public string Phone
    {
        get
        {
            return _phone;
        }
        set
        {
            int indexOfSlash = value.IndexOf("/");
            if (value.Length > 13 || indexOfSlash > 4 || indexOfSlash < 2 || value[0] != '+')
                throw new Exception("Wrong format");
    
            for (int i = 1; i < value.Length; i++)
            {
                if ((i < indexOfSlash || i > indexOfSlash) && !value[i].IsDigit())
                    throw new Exception("Wrong format");
            }
            
            _phone = value;
        }
    }
