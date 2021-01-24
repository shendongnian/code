    var listC = listA
    	.Where(x => x.Key.Contains("BarCode"))
    	.GroupBy(g => new {g.GroupIdOne, g.GroupIdTwo, g.GroupIdThree, g.Key, g.Value})
    	.Select(s =>
    		new ResultSet
    		{
    			BarCode = s.Key.Value,
    			IsPassed = listA.FirstOrDefault(a => a.Key.Equals("IsPassed")
    												 && a.GroupIdOne == s.Key.GroupIdOne
    												 && a.GroupIdTwo == s.Key.GroupIdTwo
    												 && a.GroupIdTwo == s.Key.GroupIdTwo
    
    					   )?.Value ?? ""
    		})
    	.ToList();
