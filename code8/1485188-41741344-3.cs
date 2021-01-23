		private class DataDoc
		{
			public int ID { get; set; }
			public int? Data { get; set; }
		}
		private IEnumerable<DataDoc> Search(Sort sort)
		{
			var result = searcher.Search(new MatchAllDocsQuery(), null, 99, sort);
			foreach (var topdoc in result.ScoreDocs)
			{
				var doc = searcher.Doc(topdoc.Doc);
				int id = int.Parse(doc.GetFieldable("id").StringValue);
				int data = int.Parse(doc.GetFieldable("data").StringValue);
				yield return new DataDoc
				{
					ID = id,
					Data = data == int.MinValue ? (int?)null : data
				};
			}
		}
		[Fact]
		public void SortAscending()
		{
			var sort = new Sort(new SortField("data", new NullableIntFieldCompatitorSource()));
			var result = Search(sort).ToList();
			Assert.Equal(4, result.Count);
			Assert.Equal(new int?[] { 100, 300, 400, null }, result.Select(x => x.Data));
		}
		[Fact]
		public void SortDecending()
		{
			var sort = new Sort(new SortField("data", new NullableIntFieldCompatitorSource(),true));
			var result = Search(sort).ToList();
			Assert.Equal(4, result.Count);
			Assert.Equal(new int?[] { 400, 300, 100, null }, result.Select(x => x.Data));
		}
