    string newFolder = "abcd1234";
    
    string path = System.IO.Path.Combine(
       Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
       newFolder
    );
    
    if(!System.IO.Directory.Exists(path)) {
       try {
          System.IO.Directory.CreateDirectory(path);
       } catch (IOException ie) {
          Console.WriteLine("IO Error: " + ie.Message);
       } catch (Exception e) {
          Console.WriteLine("General Error: " + e.Message);
       }
    }
