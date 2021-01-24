    int counter = 0;
    string line;
    
    // Read the file and display it line by line.
    System.IO.StreamReader file = 
       new System.IO.StreamReader("c:\\test.txt");
    while((line = file.ReadLine()) != null)
    {
       Console.WriteLine (line);
       counter++;
    }
    
    file.Close();
