    var parameter = Expression.Parameter(typeof(Member), "member");
    var predicate = Expression.Lambda<Func<Member, bool>>(
    	Enumerable.Range(0, divisions.Length)
    	.Select(i => new Expression[]
    	{
    		Expression.Equal(Expression.Property(parameter, "Division"), Expression.Constant(divisions[i])),
    		Expression.Equal(Expression.Property(parameter, "Department"), Expression.Constant(departments[i])),
    	}
    	.Aggregate(Expression.AndAlso))
    	.Aggregate(Expression.OrElse),
    	parameter);
    var query = members.Where(predicate);
