        string filePathNameToMove = "";
        string directoryPathToMove = "";
        if (File.Exists(filePathNameToMove))
        {
            string destinationFilePathName = 
                   Path.Combine(directoryPathToMove, Path.GetFileName(filePathNameToMove));
            if (!File.Exists(destinationFilePathName))
            {
                try
                {
                    File.Move(filePathNameToMove, destinationFilePathName);
                    Console.WriteLine("File Moved!");
                }
                catch (Exception e)
                {
                    Console.WriteLine("File Not Moved! Error:" + e.Message);
                }
            }
        }
