    public string Phone
    {
        get { return String.Format("{0} {1}", CountryCode, Number); }
        set
        {
            CountryCode = null;
            Number = null;
            if (value != null)
            {
                var parts = value.Split(new[] { ' ' }, 2);
                if (parts.Length == 2)
                {
                    CountryCode = parts[0];
                    Number = parts[1];
                } 
            }
        }
    }
    public string CountryCode { get; set; }
    public string Number { get; set; }
