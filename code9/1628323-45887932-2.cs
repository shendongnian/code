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
                    char[] splitOn = new char[] { ',' }; // if the csv files use comma as a delimiter
                    string[] columns = row.Split(splitOn); // this splits the row into one string per column
    
                    // the third column (columns[2]) is the first that is different for all file types.
                    if (columns[2] == "User ID")
                    {
                        Debug.WriteLine("This is file A");
                    }
                    else if (columns[2] == "Adjustment Date")
                    {
                        Debug.WriteLine("This is file B");
                    }
                    else if (columns[2] == "Product Version")
                    {
                        Debug.WriteLine("This is file C");
                    }
                    else
                    {
                        Debug.WriteLine("Unknown file type.");
                    }
    
                    break; // end the loop now - we've already done what we needed to do.
                }
            }
    
        }
    }
