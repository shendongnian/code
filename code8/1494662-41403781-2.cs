    //
    // Demonstrate UrlAnalyzer using an in memory index.
    //
    public static void testUrlAnalyzer()
    {     
        string url = @"/tlfdi/epapers/datenschutz2016/files/assets/common/downloads/page0004.pdf";
        UrlAnalyzer analyzer = new UrlAnalyzer();
        Directory directory = new RAMDirectory();
        QueryParser parser = new QueryParser(Lucene.Net.Util.Version.LUCENE_30, "url", analyzer);
        IndexWriter writer = new IndexWriter(directory, analyzer, true, new IndexWriter.MaxFieldLength(2048));
        //
        // index a document. We're only interested in the "url" field of a document.
        //
        Document doc = new Document();
        Field field = new Field("url", url, Field.Store.NO, Field.Index.ANALYZED);
        doc.Add(field);
        writer.AddDocument(doc);
        writer.Commit();
        //
        // search the index for any documents having 'page004.pdf' in the url field.
        //
        string searchText = "url:page0004.pdf";
        IndexReader reader = IndexReader.Open(directory, true);
        IndexSearcher searcher = new IndexSearcher(reader);
        Query query = parser.Parse(searchText);
        ScoreDoc[] hits = searcher.Search(query, null, 10, Sort.RELEVANCE).ScoreDocs;
        if (hits.Length == 0)
            throw new System.Exception("RamblinRose is fail!");
        //
        // search the index for any documents having the full URL we indexed.
        //
        searchText = "url:\"" + url + "\"";
        query = parser.Parse(searchText);
        hits = searcher.Search(query, null, 10, Sort.RELEVANCE).ScoreDocs;
        if (hits.Length == 0)
            throw new System.Exception("RamblinRose is fail!");
    }
