    // for deleting sub directories in temp
    foreach (string subDirectory in Directory.GetDirectories(Path.GetTempPath()))
    {
        try
        {
            Directory.Delete(subDirectory, true); 
        }
        catch
        {                       
        }
    }
    // for deleting files in temp
    foreach (string tempfile in Directory.GetFiles(Path.GetTempPath(),"*.*",SearchOption.TopDirectoryOnly))
     {
         try
         {
             System.IO.File.Delete(tempfile);
         }
         catch
         {
         }
     }
