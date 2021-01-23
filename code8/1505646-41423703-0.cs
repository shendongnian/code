    int counter = 0;
    string line;
    System.IO.StreamReader file =
				new System.IO.StreamReader("s.txt");
    while((line = file.ReadLine()) != null)
    {
    if(line.Contains("SERVERERROR") || line.Contains("ERRORSTACKTRACE") )
    	Console.WriteLine (line);
    	counter++;
    }
    	file.Close();
