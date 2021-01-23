    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
        using (Font yourFont = new Font("Arial", 12))
        {
            if (textBox3.Text != null)
            {
                string x = textBox1.Text;
                e.Graphics.DrawString(x, yourFont, Brushes.Red, new Point(5, 5));
                this.Refresh();  //add this in your button click event if you want to perform it on a click event instead.
            }
        }
    }
