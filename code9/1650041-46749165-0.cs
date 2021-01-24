    private void timer1_Tick (object sender, EventArgs e)
    {
        button1.Location = new Point (button1.Location.X + 1, button1.Location.Y);
    }
    private void button1_Click (object sender, EventArgs e)
    {
        timer1.Start ();
    }
