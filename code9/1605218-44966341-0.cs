    var idDocument = context.WebProfils
                    .Where(c => idProfiles.Contains(c.IDProfil))
                    .SelectMany(c => c.Documents).ToList();
    if (idDocument != null) // Not required. idDocument can't be null (but can be empty)
    {
         // Now the following lines are not required
         if (retrieveDocuments == null)
         {
              retrieveDocuments = idDocument;
         }
         else
         {
              retrieveDocuments.Concat(idDocument);
         }
    }
