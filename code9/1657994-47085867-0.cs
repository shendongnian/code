    var dt = DateTime.Now;
    	var ls = new List<DataPoint>();
    	ls.Add(new DataPoint { DataPointId =1, Value = 1, DateTime = dt});
    	ls.Add(new DataPoint { DataPointId =2, Value = 2, DateTime = dt});
    	ls.Add(new DataPoint { DataPointId =1, Value = 1, DateTime = DateTime.Now.AddDays(1)});
    	
    	var distincData = ls.GroupBy(l => l.DateTime).Select(g => g.First());
