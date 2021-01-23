    public static string ReadFromFile(string DirectoryPath,string FileName)
        {
            if (Directory.Exists(DirectoryPath))
            {
                string FilePath = DirectoryPath + "\\" + FileName;
                if (File.Exists(FilePath))
                {
                    return File.ReadAllText(FilePath);
                }
            }
            return "";
        }
