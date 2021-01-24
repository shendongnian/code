    private void Loop_MouseDown(object sender, MouseEventArgs e)
    {
        if(e.Button == MouseButtons.Left)
        {
            click.Enabled = true;
        }
    }
    private void Loop_MouseUp(object sender, MouseEventArgs e)
    {
        if(e.Button == MouseButtons.Left)
        {
            click.Enabled = false;
        }
    }
