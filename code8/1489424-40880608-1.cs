     private static void SwapFolderFiles(string AFolder, string BFolder)
        {
            var AFolderfiles = System.IO.Directory.GetFiles(AFolder);
            var BFolderfiles = System.IO.Directory.GetFiles(BFolder);
            
            MoveFiles(AFolder, BFolder, AFolderfiles);
            MoveFiles(BFolder, AFolder, BFolderfiles);            
        }
        private static void MoveFiles(string sourceFolder, string destinationFolder, string[] folderfiles)
        {
            foreach (var file in folderfiles)
            {
                var filename = file.Substring(file.LastIndexOf("\\")+1);
                var source = System.IO.Path.Combine(sourceFolder, filename);
                var destination = System.IO.Path.Combine(destinationFolder, filename);
                System.IO.File.Move(source, destination);
            }
        }
