    private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
    {
        mDown = scalePoint(e.Location, true);
    }
    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Left)
        {
            mLast = scalePoint(e.Location, true);
            pictureBox1.Invalidate();
        }
    }
