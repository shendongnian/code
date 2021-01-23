            Point p1 = new Point();
            p1.x = 5;
            p1.y = 10;
            List<List<Point>> points = new List<List<Point>>();
            List<Point> point = new List<Point>();
            point.Add(p1);
            points.Add(point);
            MessageBox.Show(point[0][0].x);
