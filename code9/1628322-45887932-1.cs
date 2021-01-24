    public void ValidateData()
    {
        var files = Directory.EnumerateFiles(@"C:\Projects", "*.csv");
    
        foreach (string file in files)
        {
            // get a string array with one string per row
            string[] fileRows = File.ReadAllLines(file);
    
            foreach (string row in fileRows)
            {
                // ignore blank lines
                if (row.Trim() != "")
                {
                    char[] splitOn = new char[] {','}; // if the csv files use comma as a delimiter
                    string[] columns = row.Split(splitOn); // this splits the row into one string per column
    
                    int numberOfCols = columns.Length; // this is how many columns you have
    
                    // use this info to determine the type of file.
                    if (numberOfCols == 4)
                    {
                        Debug.WriteLine("This is category A");
                    }
                    else if (numberOfCols == 5)
                    {
                        Debug.WriteLine("This is category B");
                    }
                    else if (numberOfCols == 7)
                    {
                        Debug.WriteLine("This is category C");
                    }
                    else
                    {
                        Debug.WriteLine("Unexpected file type.");
                    }
    
                    break; // end the loop now - we've already done what we needed to do.
                }
            }
    
        }
    }
