    String FolderPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
    FolderPath = Path.Combine(FolderPath,"TestFolder");
    String file = Path.Combine(FolderPath,"test.html");
    if (!File.Exists(file))
      {
        try
          {
              StreamWriter tw = new StreamWriter(File.Open(file, FileMode.OpenOrCreate, FileAccess.Write), Encoding.UTF8);
              tw.WriteLine("The very first line!");
              tw.Close();
              MessageBox.Show("File Created");
          }
          catch (Exception ex)
          {
              MessageBox.Show(ex.Message);
          }
       }
