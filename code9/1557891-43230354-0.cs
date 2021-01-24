    public string backgroundColor { get; set; } 
    public string borderColor
            {
    get
                {
                    Color c1 = System.Drawing.ColorTranslator.FromHtml(backgroundColor);
                    Color c2 = Color.FromArgb(c1.A,(int)(c1.R * 0.8), (int)(c1.G * 0.8), (int)(c1.B * 0.8));
                    return System.Drawing.ColorTranslator.ToHtml(c2);
                } 
    }
