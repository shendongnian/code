    public class FileProcessor
    {
          public void ProcessFile(string filePath)
           {
               using (var stream = File.OpenRead(filePath))
               //etc...
              
           }
    }
