    public Color PreviousColour { get; set;}
    
    public void SetColour()
    {
        PreviousColour = aButton.BackgroundColor;
        aButton.BackgroundColor = Color.FromHex("#e9e9e9");
    }
    
    public void ResetColour()
    {
        aButton.BackgroundColor = PreviousColour;
    }
