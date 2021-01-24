    public class Canvas : UserControl
    {
        public Canvas()
        {
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.UserPaint |
              ControlStyles.AllPaintingInWmPaint |
              ControlStyles.ResizeRedraw |
              ControlStyles.ContainerControl |
              ControlStyles.OptimizedDoubleBuffer |
              ControlStyles.SupportsTransparentBackColor
              , true);
        }
    
        //override OnPaint and call the method
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            // Do drawing here
        }
    }
