        foreach (Control x in this.Controls)
        {
            if (!(x is PictureBox))
               continue;
            
            if(x.Tag.ToString() != "blockies")
                continue;
            if (!pBall.Bounds.IntersectsWith(x.Bounds))
                 continue;
             this.Controls.Remove(x);
             pBally = -pBally;
             score++;
        }
