    public List<Point> FindAllNeedles()
    {
        List<Point> results = new List<Point>();
    
        for (int outerX = 0; outerX < bmpHaystack.Width - bmpNeedle.Width; outerX++)
        {
            for (int outerY = 0; outerY < bmpHaystack.Height - bmpNeedle.Height; outerY++)
            {
                for (int innerX = 0; innerX < bmpNeedle.Width; innerX++)
                {
                    for (int innerY = 0; innerY < bmpNeedle.Height; innerY++)
                    {
                        Color cNeedle = bmpNeedle.GetPixel(innerX, innerY);
                        Color cHaystack = bmpHaystack.GetPixel(innerX + outerX, innerY + outerY);
                        if (cNeedle.R != cHaystack.R || cNeedle.G != cHaystack.G || cNeedle.B != cHaystack.B)
                        {
                            goto notFound;
                        }
                    }
                }
                location = new Point(outerX, outerY);
                // collect the result
                results.Add(location);
                notFound:
                continue;
            }
        }
    
        // when you are finished looping return it
        return results;
    
    }
