    private void BtnDice_Click(object sender, EventArgs e)
    {
        if (teamBox.Checked == true)
        {
            dice.diceTeam(out string result);
            player1.Text = result;
        }
    }
