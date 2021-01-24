     for (x = xmax; x < xmax; x++)
            {
                System.Drawing.Point p1 = new System.Drawing.Point(x, x * x);
                System.Drawing.Point p2 = new System.Drawing.Point(x + 1, (x + 1) * (x + 1));
                System.Drawing.Pen pen = new System.Drawing.Pen(System.Drawing.Brushes.Black, 0.2F);
                gr.DrawLine(pen, p1, p2);
    
            }
