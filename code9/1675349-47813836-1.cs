    public static bool IsMatch(string filename, string objectName)
    {
        var segments = filename.Split('-', '_');
    
        for (int i = 0; i < segments.Length; i++)
        {
            if (string.Equals(segments[i], objectName)) return true;
    
            for (int ii = 0; ii < segments.Length; ii++)
            {
                if (ii == i) continue;
                if (string.Equals(string.Concat(segments[i], segments[ii]), objectName)) return true;
            }
        }
    
        return false;
    }
