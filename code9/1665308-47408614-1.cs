    public class BufferedPicture : PictureBox
    {
       public BufferedPicture()
       {
          this.SetStyle(ControlStyles.OptimizedDoubleBuffer | 
                        ControlStyles.UserPaint | 
                        ControlStyles.AllPaintingInWmPaint, true);
          this.UpdateStyles();
       }
    }
