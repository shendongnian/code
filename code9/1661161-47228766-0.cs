    int i = 0;  
    string line;  
    
    // Read the file and work it line by line.  
    StreamReader file = new StreamReader(@"c:\test.txt");  
    while((line = file.ReadLine()) != null)  
    {  
    string[] columns = line.Slip(' '); 
    for(int j = 0; j < column.Length; j++)
        {
         loadedBoarder[i, j] = columns[j];
        }
        i++;  
    }  
