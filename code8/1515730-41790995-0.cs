    private string _password;
    private bool _isDecrypted = false;
    public string Password
    {
        get
        {
            if(_isDecrypted == false)
            {
                _password = Decrypt(_password);
                _isDecrypted = true;
            }
            return (_password);
        }
        set
        {
            _password = Encrypt(value);
            _isDecrypted = false;
        }
    }
