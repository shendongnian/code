    private void button3_Click(object sender, EventArgs e)
    {              
        System.IO.DirectoryInfo di = new DirectoryInfo(@"C:\Users\RamRo\AppData\Local\Google\Chrome\User Data\Default\Cache");
        List<FileSystemInfo> notDeletable = new List<FileSystemInfo>();    
        foreach (FileInfo file in di.GetFiles())
        {
          try 
          {
            file.Delete();
          }
          catch (Exception ex)
          {
            notDeletable.Add(file);
          }
        }
        foreach (DirectoryInfo dir in di.GetDirectories())
        {
          try
          {
            dir.Delete(true);
          }
          catch (Exception ex)
          {
            notDeletable.Add(dir);
          }
        }
        // Process 'notDeletable' List
    }
