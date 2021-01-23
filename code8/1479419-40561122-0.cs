    public static Documents CastToDocuments(this List<Document> docs)
    {
        var toRet = new Documents();
        toRet.AddRange(docs);
        return toRet;
    }
