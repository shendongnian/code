        public void DrawLine(Point start, Point end, Control ctrl)
        {
            ctrl.Refresh();
            using ( Graphics g = activeControl.CreateGraphics())
            using ( Pen P = new Pen(Color.Red, 3) )
            {
              P.StartCap = System.Drawing.Drawing2D.LineCap.NoAnchor;
              P.CustomEndCap = 
                new System.Drawing.Drawing2D.AdjustableArrowCap(4, 8, false);
              g.DrawLine(P, start, end);
            }
        }
