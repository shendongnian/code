    String line;
    try 
    {
    //Pass the file path and file name to the StreamReader constructor
    StreamReader sr = new StreamReader("C:\\Sample.txt");
    
    //Read the first line of text
    line = sr.ReadLine();
    
    //close the file
    sr.Close();
    }
    catch(Exception e)
    {
    Console.WriteLine("Exception: " + e.Message);
    }
       finally 
    {
    Console.WriteLine("Executing finally block.");
    }
    
    
