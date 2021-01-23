    public string ColorHexa { get; set; }
    public Color Color
    {
        get => Color.FromHex(ColorHexa);
        set => ColorHexa = value.ToHexString();
    }
