    public System.Drawing.Color Hue(System.Drawing.Color color, double value)
    {
        HSLColor hslColor = new HSLColor(hue: value * 240, saturation: 240, luminosity: 120);
    
        return hslColor;
    }
