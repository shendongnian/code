    public static List<string> GetAllMatchingPaths(string pattern)
            {
                char separator = Path.DirectorySeparatorChar;
                string[] parts = pattern.Split(separator);
    
                if (parts[0].Contains('*') || parts[0].Contains('?'))
                    throw new ArgumentException("path root must not have a wildcard", nameof(parts));
    
                return GetAllMatchingPathsInternal(String.Join(separator.ToString(), parts.Skip(1)), parts[0]);
            }
    
            private static List<string> GetAllMatchingPathsInternal(string pattern, string root)
            {
                char separator = Path.DirectorySeparatorChar;
                string[] parts = pattern.Split(separator);
    
                for (int i = 0; i < parts.Length; i++)
                {
                    // if this part of the path is a wildcard that needs expanding
                    if (parts[i].Contains('*') || parts[i].Contains('?'))
                    {
                        // create an absolute path up to the current wildcard and check if it exists
                        var combined = root + separator + String.Join(separator.ToString(), parts.Take(i));
                        if (!Directory.Exists(combined))
                            return new List<string>();
    
                        if (i == parts.Length - 1) // if this is the end of the path (a file name)
                        {
                            return ( List<string> ) Directory.EnumerateFiles(combined, parts[i], SearchOption.TopDirectoryOnly);
                        }
                        else // if this is in the middle of the path (a directory name)
                        {
                            var directories = Directory.EnumerateDirectories(combined, parts[i], SearchOption.TopDirectoryOnly);
    
                            List<string> pts = new List<string>();
                            foreach ( string directory in directories )
                            {
                                foreach ( string item in GetAllMatchingPathsInternal(String.Join(separator.ToString(), parts.Skip(i + 1)), directory))
                                {
    
                                    pts.Add(item);
                                }
    
                            }
    
                            return pts;
                        }
                    }
                }
