    var bulk = new BulkOperations();
    
    using (TransactionScope trans = new TransactionScope())
    {
    	using (SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=mydb;Integrated Security=SSPI")
    	{
            bulk.Setup()
                .ForCollection(items)
                .WithTable("Items")
                .AddColumn(x => x.QuantitySold)
                .BulkUpdate()
                .MatchTargetOn(x => x.ItemID) 
                .Commit(conn);
    	}
    
    	trans.Complete();
    }
