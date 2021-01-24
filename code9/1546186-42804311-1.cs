    bool HitEdge = false;
    Point BasePoint = new Point(10,10);
    public void functionThread()
    {
        var timer2 = new Timer();
        timer2.Interval = 50;
        timer2.Enabled = true;
        timer2.Tick += timer2_Tick;
    }
    private void timer2_Tick(object sender, EventArgs e)
    {
        if((panel1.Left + panel1.Width) >= this.Width)
        {
            HitEdge = true;
        }
        if (!HitEdge )
        {
            panel1.Left += 15;
        }
        else
        {
            panel1.Location = BasePoint;
        }
    }
