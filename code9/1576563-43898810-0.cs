    public decimal Data { get; set; }
    public int RoundedData
    {
        get { return Convert.ToInt32(Math.Round(Data, 0)); }
    }
