    public class PictureBoxEx : PictureBox
    {
      public PictureBoxEx()
      {
        InitializeComponent():
        this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                      ControlStyles.UserPaint |
                      ControlStyles.OptimizedDoubleBuffer, 
                      true);
      }
    
      ...
    }
