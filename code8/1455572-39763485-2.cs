    public string Message
    {
        get
        {
            if (_description.Contains(ALERT_DESC_MARKER) && _description.Contains(PRIORITY_MARKER))
                return _description != null ? GetTextPart(_description, ALERT_DESC_MARKER, PRIORITY_MARKER).Trim(): _description;
            //if (_description.Contains(ALERT_DESC_MARKER) && _description.Contains(PRIORITY_MARKER))
            //    return _description ?? GetTextPart(_description, ALERT_DESC_MARKER, PRIORITY_MARKER).Trim();
            else
                return _description;
        }
        set
        {
            _description = value;
        }
    }
