    private void Form1_MouseMove(object sender, MouseEventArgs e)
    {
        int x = Int32.Parse(textbox1.text);
        int y = Int32.Parse(textbox2.text);
        this.Cursor = new Cursor(Cursor.Current.Handle);
        Cursor.Position = new Point(Cursor.Position.X - x, Cursor.Position.Y - y);
        Cursor.Clip = new Rectangle(this.Location, this.Size);
    }
