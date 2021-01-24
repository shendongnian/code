     private  bool CreateFolderPath(string parentPath, string pathToCreate)
            {
                try
                {
                    string[] folders = pathToCreate.Split(new string[] { "\\" }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string folderName in folders)
                    {
                        var fileTargetContentFolderTask =  Content.LoadAsync(parentPath+"/"+folderName);
                        fileTargetContentFolderTask.Wait();
                        if (fileTargetContentFolderTask.Result == null)
                        {
                            var folder = Content.CreateNew(parentPath, ConfigurationManager.AppSettings["FolderType"], folderName);
                            var task = folder.SaveAsync();
                            task.Wait();
                        }
                        parentPath += "/" + folderName;
                    }
                    return true;
                }
                catch
                {
                    return false;
                }
            }
