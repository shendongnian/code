            Point p1 = new Point(); // create new Point
            p1.x = 5;
            p1.y = 10;
            List<List<Point>> points = new List<List<Point>>(); // multidimensional list of poits 
            List<Point> point = new List<Point>();
            point.Add(p1); // add a point to a list of point
            points.Add(point); // add that list point to multidimensional list of points
            MessageBox.Show(points[0][0].x); // read index 0 "(list<point>)" take index 0 of that list "(Point object)" take the value x. "(p1.x)"
