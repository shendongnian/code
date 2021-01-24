    private void timer1_Tick(object sender, EventArgs e)
    {
        if (IsKeyDown(Keys.A))
        {
            ply.Left -= 3;
        }
        if (IsKeyDown(Keys.S))
        {
            ply.Top += 3;
        }
        if (IsKeyDown(Keys.D))
        {
            ply.Left += 3;
        }
        if (IsKeyDown(Keys.W))
        {
            ply.Top -= 3;
        }
    }
