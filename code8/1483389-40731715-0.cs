    private void Test()
    {
	   var list = new List<Expression<System.Func<table, bool>>>();
    	Expression<Func<table, bool>> query1 = temp2 => temp2.Name.Contains("test string");
    	Expression<Func<table, bool>> query2 = temp2 => temp2.ignore == false;
	    list.Add(query1);
	    list.Add(query2);
    	var temp = filterAll(list).ToList();
	}
	
    private System.Linq.IQueryable<table> filterAll(List<Expression<Func<table, bool>>> list2 )
    {
	    var query = table.AsQueryable();
    	foreach (var a in list2)
    	{
	    	query = query.Where(a);
	    }
    	return query;
    }
 
