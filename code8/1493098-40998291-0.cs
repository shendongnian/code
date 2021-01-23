    public void AttachLinesToDocs(List<LineDocuments> linesDocuments)
    {
      var qualifiedLineDocuments = linesDocuments.Where(inputld=> !dbConnection.LineDocuments.Any(ld=> ld.DocumentId== inputld.DocumentId && ld.LineId== inputld.LineId)).ToList();
          qualifiedLineDocuments.ForEach(qld=> 
          {
            dbConnection.LineDocuments.Add(qld);
          });
      }
    }
