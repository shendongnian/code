    public DateTime Date { get; set; }
    public DateTime Time { get; set; }
    public DateTime DateTima
    {
        get
        {
            return Date.Date.Add(Time.TimeOfDay);
        }
    }
