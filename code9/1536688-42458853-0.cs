    foreach (var thisLine in File.ReadLines(theFile))
    {
        int[] point = getPoint(thisLine);
    }
    
    public int[] getPoint(string line)
    {
        // Split by tab or space
        string[] portions = line.Split(new char[] { ' ', '\t' });
                
        int x = Int32.Parse(portions[0]); //find x-coordinate and turn it from a string to an int
               
        int y = Int32.Parse(portions[1]); //y-coordinate starts after first white space and ends before next
    
        int z = Int32.Parse(portions[2]); //z starts after 2nd white space and goes through end of line
    
        return new int[] { x, y, z }; //return a new point!
    }
