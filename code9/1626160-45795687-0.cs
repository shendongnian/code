    List<DocumentQuery> queries = new List<DocumentQuery>();
    // Fill queries
    RootObject root = new RootObject();
    foreach(var query in queries)
    {
        Document document = new Document()
        {
            document = new Document2()
            {
                homecommunityid = query.homecommunityid,
                repositoryid = query.repositoryid,
                documentuuid = query.documentuuid,
                doctype = query.doctype
            }
        }
        root.documents.Add(document);
    }
