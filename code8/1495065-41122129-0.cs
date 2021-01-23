    void Main()
    {
      System.Data.SQLite.SQLiteConnection con = new System.Data.SQLite.SQLiteConnection( @"Data Source="+FilePath );
      SQLiteQueryProvider provider = new SQLiteQueryProvider(con, new ImplicitMapping(), QueryPolicy.Default);
    	var data = provider.GetTable<MyTable>("MyTable")
    	.Where(mt => mt.Level1 == "M_TO" && mt.AggCode == "C_DTA")
    	.GroupBy(mt => new {mt.Date, mt.CompanyName})
    	.Select(mt => new
    	 {
    		 Date = mt.Key.Date
    		 CompanyName = mt.Key.CompanyName,
    		 Sum = mt.Sum(t => t.Amount)
    	 }
    	).ToList();
    
