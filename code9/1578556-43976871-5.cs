      Rectangle cr = adornedPanel1.ClientRectangle;
      Rectangle r = new Rectangle(0, ih2, cr.Width  - iw2, cr.Height -  ih2 );
      using (Pen pen = new Pen(Color.MediumSlateBlue, bw)
           { Alignment = System.Drawing.Drawing2D.PenAlignment.Inset})
           e.Graphics.DrawRectangle(pen, r);
      e.Graphics.DrawImage(img, cr.Right - img.Width, 0);
