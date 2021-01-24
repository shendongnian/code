    public static FileInfo CopyLockedFileRtl(DirectoryInfo directory, FileInfo fileInfo, string remoteEndPoint)
            {
                FileInfo copiedFileInfo = null;
                using (var ts = new TaskService(string.Format(@"\\{0}", remoteEndPoint)))
                {
                    var task = ts.GetTask(@"\Microsoft\Windows\Wininet\CacheTask");
                    task.Stop();
                    task.Enabled = false;
                    var byteArray = FileHelper.ReadOnlyAllBytes(fileInfo);
                    var filePath = Path.Combine(directory.FullName, "unlockedfile.dat");
                    File.WriteAllBytes(filePath, byteArray);
                    copiedFileInfo = new FileInfo(filePath);
                    task.Enabled = true;
                    task.Run();
                    task.Dispose();
                }
    
                return copiedFileInfo;
            }
