    {
    	public class MyCollectionQueryBuilder
        {
            private IQueryable<MyCollectionItem> query;
            public MyCollectionQueryBuilder(IQueryable<MyCollectionItem> query)
            {
                this.query = query;
            }
            public MyCollectionQueryBuilder WithCol1Filter(string filter)
            {
                query = query.Where(a => (a.Col1 == filter));
    			
                return this;
            }
    		
    		public IQueryable<CoreFolderResearchModelLink> Build()
            {
                return query;
            }
    	}
    }
