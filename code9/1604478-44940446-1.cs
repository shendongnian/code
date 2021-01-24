    class CustomLinkLabel : LinkLabel
    {
      protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
      {
        //MyBase.OnPaint(e)
        using (SolidBrush B = new SolidBrush(this.ForeColor)) 
        {
          e.Graphics.DrawString(this.Text, this.Font, B, e.ClipRectangle.X, e.ClipRectangle.Y);
        }
      }
    }
