    public static Bitmap ToWhiteCorrection(this Bitmap source, Color sourceColor, Color targetColor, Color maskColor, int threshold, Size tableSize, int cpu = 0)
    {
       using (var dbMask = new DirectBitmap(source))
       {
          using (var dbDest = new DirectBitmap(source))
          {
             var options = new ParallelOptions
                {
                   MaxDegreeOfParallelism = cpu <= 0 ? Environment.ProcessorCount : cpu
                };
    
             // Divide the image up
             var rects = dbMask.Bounds.GetSubRects(tableSize);
    
             Parallel.ForEach(rects, options, rect => ProcessWhiteCorrection(dbMask, dbDest, rect, sourceColor, targetColor, maskColor, threshold));
    
             return dbDest.CloneBitmap();
          }
       }
    }
      private static void ProcessWhiteCorrection(this DirectBitmap dbMask, DirectBitmap dbDest, Rectangle rect, Color sourceColor, Color targetColor, Color maskColor, int threshold)
      {
         var pixels = new Stack<Point>();
         AddStartLocations(dbMask, rect, pixels, sourceColor, threshold);
         while (pixels.Count > 0)
         {
            var point = pixels.Pop();
            if (!rect.Contains(point))
            {
               continue;
            }
            if (!dbMask[point]
                  .IsSimilarColor(sourceColor, threshold))
            {
               continue;
            }
            dbMask[point] = maskColor;
            dbDest[point] = targetColor;
            pixels.Push(new Point(point.X - 1, point.Y));
            pixels.Push(new Point(point.X + 1, point.Y));
            pixels.Push(new Point(point.X, point.Y - 1));
            pixels.Push(new Point(point.X, point.Y + 1));
         }
      }
