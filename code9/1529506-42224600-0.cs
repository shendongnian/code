    public IPAddress IP { get; set; }
    public string StringIP
    {
        get
        {
            return IP.ToString();
        }
        set
        {
            IP = IPAddress.Parse(value);
        }
    }
