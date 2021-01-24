    private void PictureBox1_MouseDown(object sender, MouseEventArgs me)
    {            
        Image b = PictureBox1.Image;
        int x = b.Width * me.X / PictureBox1.Width;
        int y = b.Height * me.Y / PictureBox1.Height;
        MessageBox.Show(String.Format("X={0}, Y={1}", x, y));
    }
