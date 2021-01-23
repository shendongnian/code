    private string _Color;
    public string Color
    {
        get
        {
            return this._Color;
        }
        set
        {
            this._Color = value;
            this.Property3 = $"{this.Color}-{this.Speed}";
        }
    }
    
    private string _Speed;
    public string Speed
    {
        get
        {
            return this._Speed;
        }
        set
        {
            this._Speed = value;
            this.Property3 = $"{this.Color}-{this.Speed}";
        }
    }
    public string Property3 { get; set; }
