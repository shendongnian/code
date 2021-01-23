    private string _Email;
    public string Email
    {
        get
        {
            if (String.IsNullOrEmpty(_Email))
            {
                _Email = GetEmailAddress();
            }
            if (String.IsNullOrEmpty(_Email))
            {
                _Email = User.Current.Preference("Email");
            }
            if (String.IsNullOrEmpty(_Email))
            {
                _Email = "";
            }
            return _Email;
        }
    }
