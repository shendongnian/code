    public Color getPixelColor(double value) {
        return colors[(int)(value / range)];
    }
    
    public void drawPixel(double value, int x, int y) {
        Brush aBrush = new SolidColorBrush(getPixelColor(value));
        Graphics g = this.CreateGraphics();
        g.FillRectangle(aBrush, x, y, 1, 1);
    }
