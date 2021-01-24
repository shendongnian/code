    bool tick;
    private void theTimer_Tick( object sender, EventArgs e )
    {
        if(tick)
        {
            colorLabel.BackColor = Color.Red;//Using label as example
        }
        else
        {
            colorLabel.BackColor = Color.Green;
        }
        tick = !tick;//Invert tick bool
    }
