        foreach (Control x in this.Controls)
        {
            if (!(x is PictureBox))
               continue;
            
            //this is needed if you want to use some specific property of the PictureBox.
            PictureBox ctl = (PictureBox)x;
            if(ctl.Tag.ToString() != "blockies")
                continue;
            if (!pBall.Bounds.IntersectsWith(ctl.Bounds))
                 continue;
             this.Controls.Remove(x);
             pBally = -pBally;
             score++;
        }
