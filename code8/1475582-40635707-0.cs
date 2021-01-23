    public static void DirectoryDeleteRobocopy(string a_strPath)
        {
            _log.Debug("DirectoryDeleteRobocopy called: " + a_strPath);
            string strTmpDir = System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var emptyDirectory = new DirectoryInfo(strTmpDir + "\\TempEmptyDir_" + Guid.NewGuid());
            try
            {
                emptyDirectory.Create();
                using (var process = new Process())
                {
                    process.StartInfo.FileName = "robocopy.exe";
                    process.StartInfo.Arguments = "\"" + emptyDirectory.FullName + "\" \"" + a_strPath + "\" /e /purge";
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.CreateNoWindow = true;
                    process.Start();
                    process.WaitForExit();
                }
                emptyDirectory.Delete();
                new DirectoryInfo(a_strPath).Attributes = FileAttributes.Normal;
                Directory.Delete(a_strPath);
            }
            catch (IOException) { }
        }
