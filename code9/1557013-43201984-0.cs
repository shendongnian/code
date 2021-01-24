    DataTable dt = new DataTable(); 
    dt.Clear();
    dt.Columns.Add("Block");
    dt.Columns.Add("Transplant");
    dt.Columns.Add("Variety");
    dt.Columns.Add("Quantity1");
    dt.Columns.Add("Quantity2");
    
    
    object[] r1 = {"A", "04/04/2017", "ROSE", 11, 11};
    object[] r2 = {"A", "04/04/2017", "ROSE", 21, 11};
    object[] r3 = {"B", "14/04/2017", "MN", 231, 11};
    object[] r4 = {"A", "24/04/2017", "GG", 11, 11};
    object[] r5 = {"A", "24/04/2017", "GG", 21, 21};
    
    dt.Rows.Add(r1);
    dt.Rows.Add(r2);
    dt.Rows.Add(r3);
    dt.Rows.Add(r4);
    dt.Rows.Add(r5);
    dt.Dump();
    
    var grouped = dt.AsEnumerable().GroupBy (d => new 
    			  { 
    			  		block = d.Field<string>("Block"), 
    					transplant = d.Field<string>("Transplant"), 
    					variety = d.Field<string>("Variety") 
    			  })
    			  .Select(x => new {
    					Block = x.Key.block,
    					Transplant = x.Key.transplant,
    					Variety = x.Key.variety,
    					//replace ItemArray Index with appropriate values in your code
    					Q1 = x.Sum(y => int.Parse(y.ItemArray[3].ToString())),
    					Q2 = x.Sum(y => int.Parse(y.ItemArray[4].ToString())),
    				});
    grouped.Dump();
