    using(System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Text\TextFile.txt"))
    {
        int loadX = 0;
        int loadY = 0;
        string line;
    
        // Loop through each line as you read it.
        while ((line = file.ReadLine()) != null)
        {
            // Split the line to get an array of values.
            string[] entries = line.Split('.');
        
            // Loop through each value and process.
            for(int i = 0; i < entries.length; i++)
            {
                string entry = entries[i];
        
                // TODO: Do something with entry.
        
                loadY++;
            }
        
            loadX++;
        }
    }
