    public static bool IsMatch(string filename, string objectName)
    {
        var segments = filename.Split('-', '_');
        var segmentCount = segments.Count();
    
        for (int i = 0; i < segmentCount; i++)
        {
            if (string.Equals(segments[i], objectName)) return true;
    
            for (int ii = 0; ii < segmentCount; ii++)
            {
                if (ii == i) continue;
                if (string.Equals(string.Concat(segments[i], segments[ii]), objectName)) return true;
            }
        }
    
        return false;
    }
