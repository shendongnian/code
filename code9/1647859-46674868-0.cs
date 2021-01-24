     //Divide WIDTH x Axis int 3 columns
            int x1 = TAPBxCanvas.Width / 2;
            //Divide HEIGHT y Axis into 3 rows;
            int y1 = TAPBxCanvas.Height / 2;
            //Find the Second point
            Point width = new Point(x1,y1);
            // - - -
            float dx = (float)TAPBxCanvas.Width / nx;
            float dy = (float)TAPBxCanvas.Height / ny;
            PenGray.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            for (int ix = 0; ix <= nx; ix++)
            {
                g.DrawLine(PenGray, ix * dx, 0, ix * dx, TAPBxCanvas.Height);
            }
            for (int iy = 0; iy <= ny; iy++)
            {
                g.DrawLine(PenGray, 0, iy * dy, TAPBxCanvas.Width, iy * dy);
            }
