    private void Button_MouseMove(object sender, MouseEventArgs e)
    {
        var button = (Button)sender;
        if (e.Button == MouseButtons.Left)
        {
            button.Left = PointToClient(Cursor.Position).X;
        }
    }
