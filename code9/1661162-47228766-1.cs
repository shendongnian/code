    int i = 0;  
    // Read the file and work it line by line.  
    string[] lines = File.ReadAllLines(gameFile); 
    foreach(string line in lines) 
        {  
        string[] columns = line.Split(' '); 
        for(int j = 0; j < columns.Length; j++)
            {
             loadedBoarder[i, j] = columns[j];
            }
            i++;  
        }  
        
