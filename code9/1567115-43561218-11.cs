    private void BtnDice_Click(object sender, EventArgs e)
    {
        if (teamBox.Checked == true)
        {
            dice.diceTeam();
            player1.Text = dice.p1;
        }
    }
