        public bool IsVisible(Point p, List<Point> points)
        {
            int i, j = points.Count - 1;
            bool isVisible = false;
            for (i = 0; i < points.Count; i++)
            {
                if (points[i].Y < p.Y && points[j].Y >= p.Y 
                    || points[j].Y < p.Y && points[i].Y >= p.Y)
                {
                    if (points[i].X + (p.Y - points[i].Y) / (points[j].Y - points[i].Y) 
                        * (points[j].X - points[i].X) < p.X)
                    {
                        isVisible = !isVisible;
                    }
                }
                j = i;
            }
            return isVisible;
        }
