    var img = new System.Drawing.Bitmap(200, 200); 
    using (var g = System.Drawing.Graphics.FromImage(img)) {
       using (var p1 = new System.Drawing.Pen(System.Drawing.Color.Black, 2),
                  p2 = new System.Drawing.Pen(System.Drawing.Color.Black, 2)) {
           using (var bigArrow = new AdjustableArrowCap(5, 5)) {
               p2.CustomEndCap = bigArrow;
               g.DrawLine(p1, 25, 50, 25, 100);
               g.DrawLine(p2, 25, 100, 25, 99);
            }
        }
    }
