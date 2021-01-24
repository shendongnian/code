        private List<List<Point>> areas = new List<List<Point>>();
        public void PopulateAreas()
        {
            //Find all the areas
            for (var y = 0; y < yMax; y += 3)
            {
                for (var x = 0; x < xMax; x += 3)
                {
                    Color col = bmp.GetPixel(x, y);
                    if (col.ToArgb() == Color.Black.ToArgb())
                    {
                        //Found a black pixel, check surrounding area
                        var area = new List<Point>();
                        area.Add(new Point(x, y));
                        areas.Add(area);
                        AppendSurroundingPixelsToArea(area, x, y);
                    }
                }
            }
            var startX = Int32.MaxValue;
            var startY = Int32.MaxValue;
            var endX = Int32.MinValue;
            var endY = Int32.MinValue;
            //Loop through list of areas. 
            foreach (var area in areas)
            {
                //Minimum size of area
                if (area.Count > 5)
                {
                    var minx = area.Min(p => p.X);
                    if (area.Min(p => p.X) < startX)
                        startX = minx;
                    //Do the same for the others...
                }
            }
        }
        public void AppendSurroundingPixelsToArea(List<Point> area, int startX, int startY)
        {
            for(var x = startX - 1; x <= startX + 1; x++)
            for (var y = startY - 1; y <= startY + 1; y++)
            {
                if ((x != 0 || y != 0) && IsBlackPixel(bmp, x, y))
                {
                    //Add to the area
                    if (PointDoesNotExistInArea(area, x, y))
                    {
                        area.Add(new Point(x, y));
                        AppendSurroundingPixelsToArea(area, x, y);
                    }
                }
            }
        }
