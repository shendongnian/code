     private string[] foldersOnly(){
      List<string> folders = new List<string>();
      string[] allFolders = Directory.GetDirectories(directory);
      foreach(string folder in allfolders){
           string[] parts = folder.Split('\\');
           folder.Add(parts[parts.Length-1]);
      }
      }
      return folders.ToArray();
  
