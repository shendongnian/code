    int cnt = 0;
    Random rnd = new Random();
    while (cnt < 5)
    {
        int idx = rnd.Next(0, 25);
        if (buttons[idx].BackColor == Color.Blue)
        {
            buttons[idx].BackColor = Color.Red;
            cnt++;
        }
    }
