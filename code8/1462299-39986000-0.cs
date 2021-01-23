    public IEnumerable<MyEntity> GetDataByDateRange(DateTime startDate, DateTime endDate)
    {
    	var dbContext = new EntityContext();
    	var dbQuery =
    		from g in (from e in dbContext.MyEntities
    				   where e.Date <= startDate
    				   group e.Date by e.Code into g
    				   select new { Code = g.Key, MaxDate = g.Max() })
    		join e in dbContext.MyEntities on g.Code equals e.Code
    		where e.Date >= g.MaxDate && e.Date <= endDate
    		orderby e.Code, e.Date
    		select e;
    
    	using (var result = dbQuery.GetEnumerator())
    	{
    		for (bool more = result.MoveNext(); more;)
    		{
    			MyEntity next = result.Current, item = null;
    			for (var date = startDate; date <= endDate; date = date.AddDays(1))
    			{
    				if (item == null || (next != null && next.Date == date))
    				{
    					item = next;
    					more = result.MoveNext();
    					next = more && result.Current.Code == item.Code ? result.Current : null;
    				}
    				else if (item.Date != date)
    					item = new MyEntity { Date = date, Code = item.Code, Value = item.Value };
    				yield return item;
    			}
    		}
    	}
    }
