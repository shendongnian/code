    private Bitmap DrawToBitmap()
    {
      using(Graphics g = this.CreateGraphics())
      {
        var bmp = new Bitmap(this.ClientSize.Width, this.ClientSize.Height, g);
        using(Graphics gBmp = Graphics.FromImage(bmp))
        {
          PaintEventArgs e = new PaintEventArgs(gBmp, this.ClientRectangle);
          this.OnPaint(e);        
        }        
      }
    }
