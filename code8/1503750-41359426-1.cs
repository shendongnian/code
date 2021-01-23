    TextBox txt;
    private void c_MouseDown(object sender, MouseEventArgs e)
    {
    if (e.Button == MouseButtons.Right)
        {
            ss = sender as Button;
            Point location = ss.Location;
            int xLocation = ss.Location.X;
            int yLocation = ss.Location.Y;
            txt = new TextBox();
            txt.Name = "textBox1";
            txt.Text = "Add Text";
            txt.Tag = ss;
            txt.Location = new Point(xLocation - 10, yLocation + 20);
            Controls.Add(txt);
            txt.Focus();
            txt.BringToFront();
            txt.KeyDown += txt_KeyDown;
        }
    }
    private void txt_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            ss = (sender as TextBox).Tag as Button;
            ss.Name = txt.Text;
            Controls.Remove(txt);
        }
    }
