     int x;
        for (x = xmin; x < xmax; x++)  // set it to the min value at first
        {
            System.Drawing.Point p1 = new System.Drawing.Point(x, x * x);
            System.Drawing.Point p2 = new System.Drawing.Point(x + 1, (x + 1) * (x + 1));
            System.Drawing.Pen pen = new System.Drawing.Pen(System.Drawing.Brushes.Black, 2F); // changed the value here
            gr.DrawLine(pen, p1, p2);
        }
