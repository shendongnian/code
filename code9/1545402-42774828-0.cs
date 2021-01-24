    string SingleNumb = "";
    string[] lines = System.IO.File.ReadAllLines(@"C:\testFile.txt");
    
    // Display the file contents by using a foreach loop.            
    foreach (string line in lines)
    {
         if((SingleNumb = line) != null)
         {
             float value = float.Parse(SingleNumb);
         }
    } 
