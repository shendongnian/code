     public static async Task<bool> TryDownloadFileAtPathAsync()
        {
            var createdFileId = await UserSnippets.CreateFileAsync(Guid.NewGuid().ToString(), STORY_DATA_IDENTIFIER);
            var fileContent = await UserSnippets.GetCurrentUserFileAsync("/Documents","Imp.zip") ;
            using (var fileStream = await Task.Run(() => System.IO.File.Create(ApplicationData.Current.LocalFolder.Path + "\\Imp.zip")))
            {
                fileContent.Seek(0, SeekOrigin.Begin);
                fileContent.CopyTo(fileStream);
            }
           return fileContent != null;
        }
