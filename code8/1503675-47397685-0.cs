    public IActionResult GetZip([FromBody] List<DocumentAndSourceDto> documents)
    {
        List<Document> listOfDocuments = new List<Document>();
    
        foreach (DocumentAndSourceDto doc in documents)
            listOfDocuments.Add(_documentService.GetDocumentWithServerPath(doc.Id));
    
        using (var ms = new MemoryStream())
        {
            using (var zipArchive = new ZipArchive(ms, ZipArchiveMode.Create, true))
            {
                foreach (var attachment in listOfDocuments)
                {
                    var entry = zipArchive.CreateEntry(attachment.FileName);
    
                    using (var fileStream = new FileStream(attachment.FilePath, FileMode.Open))
                    using (var entryStream = entry.Open())
                    {
                        fileStream.CopyTo(entryStream);
                    }
                }
    
            }
            ms.Position = 0;
            return File(ms.ToArray(), "application/zip");
        }
    
        throw new ErrorException("Can't zip files");
    }
