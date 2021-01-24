    List<string> Lines = new List<string>(readData.Replace("\r\n", "\n").Split('\n'));
    while (Lines.Count > 0 && !Lines[0].StartsWith("---"))    
    {
        Match M = Regex.Match(Lines[0], @"^[\d]+ bytes from ([^:]+): [^ ]+ ttl=([\d]+) time=([^ ]+) ms");
    
        if (M != null && M.Success)
        {
            string IP = M.Groups[1].Value;
            string TTL = M.Groups[2].Value;
            string timeStr = M.Groups[3].Value;
    
            Console.WriteLine(String.Format("Ping to {0} took {2} ms with a ttl of {1}", IP, TTL, timeStr));
            // Parsing the timeStr will work the same way as above
        }
    
        Lines.RemoveAt(0);
    }
       
