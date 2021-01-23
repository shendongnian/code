    /// <summary>
    /// Print headings (column letter and row numbers)
    /// </summary>
    public bool ShowHeaders
    {
        get
        {
            return GetXmlNodeBool(_headersPath, false);
        }
        set
        {
            SetXmlNodeBool(_headersPath, value, false);
        }
    }
