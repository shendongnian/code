    private void button1_Click(object sender, EventArgs e)
        {
            int Player_Turn = Convert.ToInt32(player_turntxt.Text);
            if (Player_Turn == 1)
            {
                button1.Text = "X";
                player_turntxt.Text = "2";
                button1.Enabled = false;
               
            }
            else
            {
                button1.Text = "O";
                player_turntxt.Text = "1";
                button1.Enabled = false;
                
            }
    
    CheckIfSomeoneHasWon();
    }
