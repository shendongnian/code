    private void timer1_Tick(object sender, EventArgs e)
    { 
        var picList = u.Controls.OfType<PictureBox>().FirstOrDefault(x => x.Name.StartsWith("invader");
        foreach(PictureBox pic in picList)
            pic.Location = new Point(pic.Location.X, pic.Location.Y + 1);
    }
