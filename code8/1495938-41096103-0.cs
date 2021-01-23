    public DateTime Date { get; set; }
    public string Time { get; set; }
    public DateTime DateTime
    {
        get
        {
            return Date.Date.Add(TimeSpan.Parse(Time));
        }
    }
