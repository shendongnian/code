    public JsonResult GetSalesData()
    {
    	using (Ctxdb dc = new Ctxdb())
    	{
    
    
    		var v = (from a in dc.SalesRecords
    				 group a by a.SalesDate.Year into g
    				 select new
    				 {
    					 Year = g.Key,
    					 Electronics = g.Sum(a => a.Electronics),
    					 BookAndMedia = g.Sum(a => a.BookAndMedia),
    					 HomeAndKitchen = g.Sum(a => a.HomeAndKitchen)
    				 });
    		if (v != null)
    		{
    			var chartData = new object[v.Count()];
    			int j = 0;
    			foreach (var i in v)
    			{
    				j++;
    				chartData[j] = new object { Year = i.Year, Electronics = i.Electronics, BookAndMedia = i.BookAndMedia, HomeAndKitchen = i.HomeAndKitchen };
    			}
    			return new JsonResult { Data = new {
    				Fields = new string[] {"Year", "Electronics", "Books and Media", "Home and KitchenKFC"},
    				Data = chartData
    			} , JsonRequestBehavior = JsonRequestBehavior.AllowGet };
    		}
    	}
    	return new JsonResult { Data = null, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
    }
