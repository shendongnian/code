    public DateTime Date { get; set; }
    public string Time { get; set; }
    public DateTime DateTime
    {
        get
        {
             return Date.Date.Add(DateTime.ParseExact(Time, "h:mm tt", CultureInfo.InvariantCulture).TimeOfDay);
        }
    }
