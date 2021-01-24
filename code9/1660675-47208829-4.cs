    double GetSum(int idToMatch, IGrouping<object, DataRow> dataRows)
    {
    	try
    	{
    		return dataRows.Where(x => (int)x[2] == idToMatch).Sum(x => double.Parse(x[3].ToString()));
    	}
    	catch (Exception e)
    	{
    		throw new Exception($"Failure when matching {idToMatch} with group {dataRows.Key}", e);
    	}
    }
... 
		var pivotedOperands = Operands.GroupBy(o => new { outputid = o[0], unitid = o[1] })
			.Select(g => new
			{
				PivotKey = g.Key,
				c1 = GetSum(1, g),
				r1 = GetSum(2, g),
				a1 = GetSum(3, g)
			});
