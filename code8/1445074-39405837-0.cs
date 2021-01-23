    //Read all the lines from FileA
    var FileAContents = File.ReadAllLines(PathFileA);
    
    //Read FileB one line at a time, and compare with FileA to search for matches.
    string line;
    StreamReader file = new StreamReader(PathFileB);
    while ((line = file.ReadLine()) != null)
    {
        //Start by finding all the possible matches, where the line from FileB starts with something that can be found in FileA.
        List<string> possibleMatches = FileAContents.Where(m => line.StartsWith(m)).ToList();
        foreach(string pm in possibleMatches)
        {
            //If the lines are completely equal, you've found a match.
            if(pm.Equals(line))
            {
                Console.WriteLine("Match found, FileA: {0}, FileB: {1}", pm, line);
            }
            else if(line.EndsWith("00"))
            {
                //Remove the "00", then check if you've found a match.
                string tempLine = line.Substring(0, line.Length - 2);
                if(pm.Equals(tempLine))
                {
                    Console.WriteLine("Match found, FileA: {0}, FileB: {1}", pm, line);
                }
            } 
        }
    }
