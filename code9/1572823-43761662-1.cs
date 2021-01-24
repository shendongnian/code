     private void Form1_Paint(object sender, PaintEventArgs e)
     {
            var pt1 = new Point(25, 25);
            var pt2 = new Point(25, 75);
            var ptMed = new Point((pt1.X + pt2.X) / 2, (pt1.Y + pt2.Y) / 2);
            var g = e.Graphics;
            var lbl = "1";
            var offsetY = (int)g.MeasureString(lbl, this.Font).Height + 2;
            var offsetX = (int)g.MeasureString(lbl, this.Font).Width + 2;
            ptMed.Y -= offsetY;
            ptMed.X -= offsetX;
            var p = new Pen(Brushes.White);
            g.DrawLine(p, pt1, pt2);
            g.DrawString(lbl, this.Font, Brushes.White, ptMed);
     }
