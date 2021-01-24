    private static void ProcessWhiteCorrection(this DirectBitmap dbMask, DirectBitmap dbDest, Rectangle rect, Color sourceColor, Color targetColor, Color maskColor, int threshold)
    {
       var pixels = new Stack<Point>();
    
       // this basically looks at a 5 by 5 rectangle in all 4 corners of the current rect
       // and looks to see if we are all the source color
       // basically it just picks good places to start the fill
       AddStartLocations(dbMask, rect, pixels, sourceColor, threshold);
    
       while (pixels.Count > 0)
       {
          var point = pixels.Pop();
    
          if (!rect.Contains(point))
          {
             continue;
          }
    
          if (!dbMask[point].IsSimilarColor(sourceColor, threshold))
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
