    public Form1()
    {
        timer.Enabled = true;
        timer.Interval = 2000;
    }
    KeyCode keyPressed;
    
    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
        keyPressed = e.KeyCode;
    }
    private void Timer1_Tick(object sender, EventArgs e)
    {
        if (keyPressed == Keys.D)
        {
            // do something
        }
    }
