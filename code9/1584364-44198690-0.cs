    public static void ClearLuceneIndexRecord(int record_id)
     {
       // init lucene
       var analyzer = new PanGuAnalyzer();
       using (var writer = new IndexWriter(_directory, analyzer, IndexWriter.MaxFieldLength.UNLIMITED))
       {
         // remove older index entry
         var DocIdToDelete= new TermQuery(new Term("id", record_id.ToString()));
         writer.DeleteDocuments(DocIdToDelete);
         // close handles
         analyzer.Close();
         writer.Dispose();
       }
    }
