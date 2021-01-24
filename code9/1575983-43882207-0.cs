    private string[] _identify;
    public string[] identify
    {
        get
        {
            if (_identify == null)
            {
                _identify = url.Text.Split('/');
            }
            return _identify;
        }
    }
