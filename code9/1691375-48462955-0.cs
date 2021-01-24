    public Int64 TimeSpanTicks{ get; set; }     
    [NotMapped]
    public TimeSpan Time 
    {
        get { return TimeSpan.FromTicks(TimeSpanTicks); }
        set { TimeSpanTicks= value.Ticks; }
    }
