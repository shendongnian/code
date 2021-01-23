    public void AttachLinesToDocs(List<LineDocuments> linesDocuments)
    {
        var insertValid = from doc in linesDocuments
                          where !dbConnection.LineDocuments
                            .Any(x => x.DocumentId == doc.DocumentId && x.LineId == doc.LineId)
                          select doc;
        foreach (LineDocuments lineDocument in insertValid)
        {
            dbConnection.LineDocuments.Add(lineDocument);
        }
        dbConnection.SaveChanges();
    }
