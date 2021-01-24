    public decimal TotalAmount1 { get; set; }
    [DataMember(Name = "TotalAmount1")]
    private string TotalAmount1Serialized { get; set; }
    [OnSerializing]
    void OnSerializing(StreamingContext context)
    {
        this.TotalAmount1Serialized = TotalAmount1.ToString("F");
    }
    [OnDeserialized]
    void OnDeserializing(StreamingContext context)
    {
        this.PerformanceDate = (...)
    }
