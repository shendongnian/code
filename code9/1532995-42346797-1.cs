            static void Main(string[] args)
            {
               // path to the desktop
               string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
               // Get the info of the desktop directory
               DirectoryInfo info = new DirectoryInfo(desktopPath);
               var images = GetFilesByExtensions(info,".png", ".jpg", ".exe", ".gif");
               // loop true all the images found by the GetFilesByExtensions() method
               foreach (var image in images)
               {
                 // Copy the images to the new folder make sure that the folder exists
                 File.Copy(desktopPath + "//"+ image.Name, desktopPath + "//folderr//" + image.Name, true);
               }
            }
           public static IEnumerable<FileInfo> GetFilesByExtensions(DirectoryInfo dir, params string[] extensions)
           {
              if (extensions == null) { throw new ArgumentNullException("extensions");}
              IEnumerable<FileInfo> files = dir.EnumerateFiles();
              return files.Where(f => extensions.Contains(f.Extension));
           }
