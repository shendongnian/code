    private void button2_Click(object sender, EventArgs e)
    {
    
        picSymbol = Properties.Resources.Player;
    
        //Will only run if button is disabled, which is after the first player creation.
        if (!button2.Enabled){
            MessageBox.Show("Too Many Player", "Player number exceed",
            MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        else
        {
            button2.Enabled = false;
        }
    } 
