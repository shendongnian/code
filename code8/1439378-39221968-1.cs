       private void panel1_Paint(object sender, PaintEventArgs e)
       {
          using ( Pen P = new Pen(Color.Red, 3) )
          {
             P.StartCap = System.Drawing.Drawing2D.LineCap.NoAnchor;
             P.CustomEndCap = 
                new System.Drawing.Drawing2D.AdjustableArrowCap(4, 8, false);
             e.Graphics.DrawLine(P, start, end);
          }
       }
