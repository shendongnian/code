    private int i = 0; // initialized once in this UI class
    
    private void timer1_Tick(object sender, EventArgs e)
    {
        label1.Text = i.ToString();
        i++; // will increment by one each time the timer is ticking
    }
    
