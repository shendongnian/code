    using (Entities context = new Entities())
    {
        using (var dbContextTransaction = context.Database.BeginTransaction())
        {
            context.Documents.AddRange(documents);
            context.SaveChanges();
            var connectorDocuments = from doc in documents
                                     select new Connector_Document 
                                     {
                                         ConnectorId = connectorId,
                                         DocumentId = doc.DocumentId
                                     };
            context.Connector_Document.AddRange(connectorDocuments);
            context.SaveChanges();
            dbContextTransaction.Commit();
        }
    }
