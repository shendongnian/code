    private void button2_Click(object sender, EventArgs e)
    {
    
        picSymbol = Properties.Resources.Player;
        Button btn = sender as Button;
        //Will only run if button is disabled, which is after the first player creation.
        if (!btn.Enabled){
            MessageBox.Show("Too Many Player", "Player number exceed",
            MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            //or
            btn.Text = "Game Disabled";
        }
        else
        {
            btn.Enabled = false;
        }
    } 
