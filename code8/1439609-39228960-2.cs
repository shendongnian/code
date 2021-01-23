    string folderPath = Dts.Variables["User::errorDirectory"].Value.ToString();
            string archivePath = @"\\SERVER\placeholderfilepath\blah\blah";
            var FileNames = new List<string>();
            var FilePaths = new List<string>();
            DirectoryInfo directoryInfo = new DirectoryInfo(folderPath);
            FileInfo[] files = directoryInfo.GetFiles();
            var lineCount = 0;
            foreach (FileInfo fileInfo in files)
            {
                lineCount = File.ReadAllLines(fileInfo.FullName).Count();
                //MessageBox.Show(lineCount.ToString());
                if (lineCount == 1) 
                {
                    File.Move(fileInfo.FullName, Path.Combine(archivePath, fileInfo.Name));
                }
            }
            Dts.TaskResult = (int)ScriptResults.Success;
