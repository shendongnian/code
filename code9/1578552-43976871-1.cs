      Rectangle cr = adornedPanel1.ClientRectangle;
      Rectangle r = r = new Rectangle(0, ih / 2, cr.Width  - iw / 2, cr.Height -  ih / 2 );
      using (Pen pen = new Pen(Color.MediumSlateBlue, bw)
           { Alignment = System.Drawing.Drawing2D.PenAlignment.Inset})
           e.Graphics.DrawRectangle(pen, r);
      e.Graphics.DrawImage(img, cr.Right - img.Width, 0);
