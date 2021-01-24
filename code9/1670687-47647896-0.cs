    private TimeSpan _toHour = TimeSpan.Zero;
    public string ToHour
    {
        get => _toHour.ToString("hh\\:mm\\:ss");
        set
        {
            _toHour = value.Contains(":") ? TimeSpan.Parse(value) : TimeSpan.ParseExact(value, "%h", CultureInfo.InvariantCulture);
            OnPropertyChanged(nameof(ToHour));
        }
    }
