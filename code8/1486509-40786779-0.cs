    private void DeleteAllTempFiles()
    {
       try
       {
           //Get the temp Path
           DirectoryInfo tempDir = new DirectoryInfo(Path.GetTempPath());
           //Get all matching files
           List<FileInfo> tempFiles = tempDir.GetFiles("tmp????.tmp", SearchOption.AllDirectories).ToList();
       
           //Collect all files that fail to delete
           List<FileInfo> cannotDelete = new List<FileInfo>();
       
           //Delete Files:
           DeleteFiles(tempFiles, out cannotDelete);
           //Show what failed (and retry or whatever)
           string message = "Cannot delete the following file(s):";
           cannotDelete.ForEach(file => message += "{file.FullName}{Environment.NewLine}");
           MessageBox.Show(message, "Result");
       }
       catch (Exception ex)
       {
           Debug.Fail(ex.Message);
       }
    }
    
    private void DeleteFiles(List<FileInfo> filesToDelete, out List<FileInfo> failedToDelete)
    {
       foreach(FileInfo file in filesToDelete)
       {   
          try
          {
             file.Delete();
          }
          catch (IOException ioEx)
          {
             failedToDelete?.Add(file); //<-- Check if failedToDelete != null !!!
             //This will always happen.
             //Since its not "hard fail" you should log it but keep goin !
             //MessageBox.Show($"IO-Exception: {ioEx.Message}");
          }
          catch (Exception ex)
          {
             MessageBox.Show($"Exception: {ex.Message}");
          }
       }
    }
