    var originTime = new System.DateTime(1970, 1, 1);
    IEnumerable<DataRecord1> records;
    
    using (var sr = new StreamReader(@"C:\Users\me\Desktop\file.csv"))
    {
    	var reader = new CsvReader(sr);
    	records = reader.GetRecords<DataRecord1>();
    }
    
    DateTime t;
    var result = from r in records
    			 let sWhen = r.TimeWhen
    			 let When = DateTime.TryParse(sWhen, out t) ? t : (DateTime?)null
    			 let span = When - originTime
    			 let Epoch = span.HasValue ? span.Value.TotalSeconds : (double?)null
    			 select new
    			 {
    				 sWhen,
    				 When,
    				 Epoch
    			 };
    // result.Take(5).ToList()
