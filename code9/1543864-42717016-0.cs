    private void Form3_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode==Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Left ||e.KeyCode == Keys.Right)
        {
            e.Handled = true;
            MovePlayer(e.KeyCode);
        }
    }
    private void MovePlayer(Keys key)
    {
        switch (key)
        {
            case Keys.Up:
                // your player moveup code
                break;
            ...
        }
    }
