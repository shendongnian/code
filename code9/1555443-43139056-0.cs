    private void winCon(object sender, int index)
    {
        int xLocation = index % Width;
        int yLocation = index / Width;
        int j = xLocation + Width * yLocation;
        bool end = true;
        for (int k = 50; k < 150; k = k + 50)
        {
            if (gameButtons[j + k] != gameButtons[j])
            {
                end = false;
            }
        }
        if (end == true)
        {
            if (gameButtons[j].BackColor == Color.Blue)
            {
                MessageBox.Show("There is a blue match");
            }
            if (gameButtons[j].BackColor == Color.Red)
            {
                MessageBox.Show("There is a red match");
            }
        }
    }
