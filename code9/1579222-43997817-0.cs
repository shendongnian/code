    private void timer1_Tick(object sender, EventArgs e)
    { 
        PictureBox pic = u.Controls.OfType<PictureBox>().FirstOrDefault(x => x.Name = "invader" + currentPicNumber;
        if(pic != null) pic.Location = new Point(pic.Location.X, pic.Location.Y + 1);
    }
