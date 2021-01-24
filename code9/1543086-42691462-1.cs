    // The original query. Must be declared here and put into variable
    // to avoid exception due to `Skip` / `Take` subquery processing EF bug
    // It still will be executed as part of the other query
    var details = ...;
    var result = db.fooDocument
        .Where(d => d.DocumentID == id).
        .Select(doc => new
        {
            Document = new
            {
                doc.DocumentID,
                doc.DocDate,
                doc.RegNumber,
                doc.UserID,
                doc.RecordDate,
                doc.RecordStatusID,
                doc.RegistrationDate,
                doc.Number,
                doc.Description,
                doc.ObjectID,
                doc.DocumentTypeID,
                doc.ContragentName,
                DocumentTypeName = doc.fooDocumentType.Name
            },
            Summa = ...,
            Total = ...,
            Details = details
        })
        .FirstOrDefault();
