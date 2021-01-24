    foreach (Control x in this.Controls)
    {
        if (x is PictureBox && x.Tag.ToString() == "blockies")
        {
            if (pBall.Bounds.IntersectsWith(x.Bounds))
            {
                this.Controls.Remove(x);
                pBally = -pBally;
                score++;
            }
        }
    }
