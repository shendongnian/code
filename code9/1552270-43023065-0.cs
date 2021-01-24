    private void threeInARow(int a, int b, int c)
    {
        if (gameButtons[a].Text == gameButtons[b].Text && gameButtons[a].Text == gameButtons[c].Text)
        {
            if (gameButtons[a].Text == "X")
            {
                MessageBox.Show("the winner is crosses");
            }
            else
            {
                MessageBox.Show("the winner is noughts");
            }
        }
    }
