    int cnt = 0;
    Random rnd = new Random();
    while (cnt < 5)
    {
        int row = rnd.Next(Rows);
        int col = rnd.Next(Cols);
        if (buttons[row, col].BackColor == Color.Blue)
        {
            buttons[row, col].BackColor = Color.Red;
            cnt++;
        }
    }
