    public static void Main() 
    {
        string path = @"c:\PathToFile\DATA10.txt";
        try 
        {        
            using (FileStream fs = new FileStream(path, FileMode.Open)) 
            {
                using (StreamReader sr = new StreamReader(fs)) 
                {
                     //blahblah    
                }
            }
        } 
        catch (Exception e) 
        {
            Console.WriteLine("The process failed: {0}", e.ToString());
        }
    }
