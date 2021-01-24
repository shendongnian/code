    var listB = listA
    	.Where(x => x.Key.Contains("BarCode"))
    	.GroupBy(g => new { g.GroupIdOne, g.GroupIdTwo, g.GroupIdThree, g.Key, g.Value })
    	.Select(s => new ResultSet { BarCode = s.Key.Value, IsPassed = $"{s.Key.GroupIdOne}|{s.Key.GroupIdTwo}|{s.Key.GroupIdThree}" })
    	.ToList();
    
    for (var i = 0; i < listB.Count(); i++)
    {
    	listB[i].IsPassed = listA.FirstOrDefault(x => x.Key.Equals("IsPassed")
    											  && x.GroupIdOne == int.Parse(listB[i].IsPassed.Split('|')[0])
    											  && x.GroupIdTwo == int.Parse(listB[i].IsPassed.Split('|')[1])
    											  && x.GroupIdThree == int.Parse(listB[i].IsPassed.Split('|')[2])
    					)?.Value ?? "";
    }
    
