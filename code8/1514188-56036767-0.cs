    public static void WriteToFile(string DirectoryPath,string FileName,string Text)
        {
            //Check Whether directory exist or not if not then create it
            if(!Directory.Exists(DirectoryPath))
            {
                Directory.CreateDirectory(DirectoryPath);
            }
            string FilePath = DirectoryPath + "\\" + FileName;
            //Check Whether file exist or not if not then create it new else append on same file
            if (!File.Exists(FilePath))
            {
                File.WriteAllText(FilePath, Text);
            }
            else
            {
                Text = $"{Environment.NewLine}{Text}";
                File.AppendAllText(FilePath, Text);
            }
        }
