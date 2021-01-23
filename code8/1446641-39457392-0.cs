    private string _Email;
    public string Email
    {
        get
        {
            if (String.IsNullOrEmpty(_Email))
            {
                _Email = GetEmailAddress();
            }
            if (_Email.IsEmptyOrNull())
            {
                _Email = User.Current.Preference("Email");
            }
            if (_Email.IsEmptyOrNull())
            {
                _Email = "";
            }
            return _Email;
        }
    }
