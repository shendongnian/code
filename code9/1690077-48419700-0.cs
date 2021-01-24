    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {          
        if (e.KeyCode == Keys.Down)
        {
            direction = 4;
        }
        if (e.KeyCode == Keys.Up)
        {
            direction = 2;
        }
        if (e.KeyCode == Keys.Right)
        {
            direction = 3;
        }
        if (e.KeyCode == Keys.Left)
        {
            direction = 1;
        }
        while (direction != 0)
        {
            Application.DoEvents();
            if (direction == 1)
            {
                X = X - 1;
            }
            else if (direction == 2)//up
            {
                Y = Y - 1;
            }
            else if (direction == 3)
            {
                X = X + 1;
            }
            else if (direction == 4)//down
            {
                Y = Y + 1;
            }
            Thread.Sleep(100);
            label1.Location = new Point(X, Y);
        }
    }
