    System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Text\TextFile.txt"); 
    int loadX = 0;
    int loadY = 0;
    string line;
    // Loop each line.
    while ((line = file.ReadLine()) != null)
    {
        // Split the line.
        string[] entries = line.Split('.');
    
        for(int i = 0; i < entires.length; i++)
        {
            string num = entires[y];
    
            // Do something with num.
    
            loadY++;
        }
    
        loadX++;
    }
