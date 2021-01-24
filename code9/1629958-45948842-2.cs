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
             //Also this line will create you a problem, because you will change the Control collection 
             //when you try to enumerate it. This should throw you an exception. Better make the control not visible.
             //this.Controls.Remove(x);
             x.Visible = false;
             pBally = -pBally;
             score++;
        }
