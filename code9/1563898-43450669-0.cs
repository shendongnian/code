    class Draw
    {
        public void Paint(PaintEventArgs e)
        {
              e.Graphics.DrawRectangles(Pens.Blue, GetRectangle());                        
        }
    }
