	public class Test
	{
		private static object syncObj = new object();
		private System.Threading.Timer timer;
		private Searcher searcher;
		private IndexWriter writer;
		private IndexReader reader;
		public Test()
		{
			writer = new IndexWriter(new RAMDirectory(), new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30), true, IndexWriter.MaxFieldLength.LIMITED);
			reader = writer.GetReader();
			searcher = new IndexSearcher(reader);
			timer = new System.Threading.Timer(Timer_Elapsed, null, TimeSpan.Zero, TimeSpan.FromMinutes(3));
		}
		public void CreateDocument(string title, string content)
		{
			var doc = new Document();
			doc.Add(new Field("A", title, Field.Store.YES, Field.Index.NO));
			doc.Add(new Field("B", content, Field.Store.YES, Field.Index.ANALYZED));
			writer.AddDocument(doc);
		}
		public void ReplaceAll(Dictionary<string, string> es)
		{
			// pause timer
			timer.Change(Timeout.Infinite, Timeout.Infinite);
			writer.DeleteAll();
			foreach (var e in es)
			{
				AddDocument(e.Value.ToString(), e.Key);
			}
			
			// restart timer
			timer.Change(TimeSpan.Zero, TimeSpan.FromMinutes(3));
		}
		public List<Document> Search(string queryString)
		{
			var documents = new List<Document>();
			var parser = new QueryParser(Lucene.Net.Util.Version.LUCENE_30, "B", new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30));
			Query query = parser.Parse(queryString);
			int hitsPerPage = 5;
			var collector = TopScoreDocCollector.Create(2 * hitsPerPage, true);
			searcher.Search(query, collector);
			ScoreDoc[] hits = collector.TopDocs().ScoreDocs;
			int hitCount = collector.TotalHits > 10 ? 10 : collector.TotalHits;
			for (int i = 0; i < hitCount; i++)
			{
				ScoreDoc scoreDoc = hits[i];
				int docId = scoreDoc.Doc;
				float docScore = scoreDoc.Score;
				Document doc = searcher.Doc(docId);
				documents.Add(doc);
			}
			return documents;
		}
		private void Timer_Elapsed(object sender)
		{
			if (reader.IsCurrent())
				return;
			reader = writer.GetReader();
			var newSearcher = new IndexSearcher(reader);
			Interlocked.Exchange(ref searcher, newSearcher);
			Debug.WriteLine("Searcher updated");
		}
		public Result ServeRequest(string searchTerm)
		{
			var documents = Search(searchTerm);
			//somelogic
			var result = new Result();
			return result;
		}
	}
