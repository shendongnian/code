    private void button2_Click(object sender, EventArgs e)
    {
    
        picSymbol = Properties.Resources.Player;
    
        //Will only run if button is disabled, which is after the first player creation.
            button2.Enabled = false;
            btn.Text = "Game Disabled";
    } 
