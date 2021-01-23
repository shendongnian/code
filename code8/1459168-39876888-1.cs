    public DateTime RecordingTime { get; set; }
    [ProtoMember(1)]
    private long RecordingTimeSerialized {
        get { return DateTimeToUnixTime(RecordingTime); }
        set { RecordingTime = UnixTimeToDateTime(value); }
    }
