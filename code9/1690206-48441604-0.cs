    public void ExportFilesToZip()
    {
        string zipFilePath = Path.GetTempPath() + "Test.zip";
        string zipFileName = "Test.zip";
        string firstFileName = "FirstFile.txt";
        string secondFileName = "SecondFile.txt";
        string firstFileContent ="1";
        string secondFileContent ="2";
    
        using (var memoryStream = new MemoryStream())
        {
            using (var archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
            {
                var demoFile = archive.CreateEntry(firstFileName);
    
                using (var entryStream = demoFile.Open())
                using (var streamWriter = new StreamWriter(entryStream))
                {
                    streamWriter.Write(firstFileContent);
                }
    
                 demoFile = archive.CreateEntry(secondFileContent);
    
                using (var entryStream = demoFile.Open())
                using (var streamWriter = new StreamWriter(entryStream))
                {
                    streamWriter.Write(secondFileName);
                }
            }
    
            using (var fileStream = new FileStream(zipFilePath, FileMode.Create))
            {
                memoryStream.Seek(0, SeekOrigin.Begin);
                memoryStream.CopyTo(fileStream);
            }
    
            var response = System.Web.HttpContext.Current.Response;
            response.BufferOutput = true;
            response.Clear();
            response.ClearHeaders();
            response.ContentEncoding = Encoding.Unicode;
            response.AddHeader("content-disposition", "attachment; filename=" + zipFileName);
            response.ContentType = "text/plain";
            response.WriteFile(zipFilePath);
            response.End();
        }
    }
