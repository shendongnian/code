    public void ExportFilesToZip()
    {
        string zipFileName = "Test.zip";
        string firstFileName = "FirstFile.txt";
        string secondFileName = "SecondFile.txt";
        string firstFileContent ="1";
        string secondFileContent ="2";
    
        Response.Clear();
        Response.ClearContent();
        Response.ClearHeaders();
        Response.AddHeader("content-disposition", "attachment;filename=" + zipFileName);
    
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
    
                demoFile = archive.CreateEntry(secondFileName);
    
                using (var entryStream = demoFile.Open())
                using (var streamWriter = new StreamWriter(entryStream))
                {
                    streamWriter.Write(secondFileContent);
                }
            }
    
            using (var fileStream = Response.OutputStream)
            {
                memoryStream.Seek(0, SeekOrigin.Begin);
                memoryStream.CopyTo(fileStream);
            }
        }
    
        Response.End();
    }
