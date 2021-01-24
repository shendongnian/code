    private void regclick(object sender, EventArgs e)
    {
        var control = (Control)sender;
      
        if (control.BackColor== Color.White)
        {
            control.BackColor = Color.Red;
            MessageBox.Show("Game Over");
            clearRow(5);
        }
        else if (control.BackColor == Color.Black)
        {
            moveLocation();
        }
    }
