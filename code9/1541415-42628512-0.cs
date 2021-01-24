    public void DibujarLimites()
    {
        using (Graphics g = CreateGraphics())
        {
            using (Pen pen = new Pen(Color.Red, 2))
            {
                float[] dashValues = { 5, 2, 15, 4 };
                pen.DashPattern = dashValues;
                DrawCircle(g, pen, this.height/2, this.width/2, 20);
            }
        }
    }
