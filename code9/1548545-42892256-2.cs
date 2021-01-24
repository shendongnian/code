    if (P.Start()){
        DateTime endTime = DateTime.Now.AddSeconds(5);
        while(!P.HasExited){
            readData = P.StandardOutput.ReadLine(); // This will wait for the next line to be output completely
            Match M = Regex.Match(Lines[0], @"^[\d]+ bytes from ([^:]+): [^ ]+ ttl=([\d]+) time=([^ ]+) ms");
            if (M != null && M.Success)
            {
                string IP = M.Groups[1].Value;
                string TTL = M.Groups[2].Value;
                string timeStr = M.Groups[3].Value;
        
                Console.WriteLine(String.Format("Ping to {0} took {2} ms with a ttl of {1}", IP, TTL, timeStr));
            }
            if (endTime > DateTime.Now)
                P.Kill();
        }
    }
