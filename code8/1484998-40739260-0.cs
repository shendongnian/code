    private void button2_Click(object sender, EventArgs e)
    {
    
        picSymbol = Properties.Resources.Player;
    
        foreach (var control in this.Controls)
        {
            if (control is Button)
            {
                control.Enabled = false;
            }
        }
    } 
