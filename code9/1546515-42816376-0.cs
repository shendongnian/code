    public bool findValueInFile(string filePath, string value)
    {
        //Get all lines from the txt file
        string[] lines = File.ReadAllLines(filePath);            
        //Go thru all the lines
        foreach(string line in lines)
        {
            //If we find the line we're looking for
            if (line.Equals(value))
            {
                return true;
            }
        }
        //If we haven't found anything return false
        return false;
    }
