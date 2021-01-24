    var changeInfo = Expression.Parameter(typeof(MyEntity), "x");
    var targetDate = Expression.Property(changeInfo, DateFilter.DateType.ToString());
    // Assuming DateFilter is a field/property/variable of type MyDateFilter    
    var dateFilter = Expression.Constant(DateFilter);
    var firstDate = Expression.Property(dateFilter, "FirstDate");
    var secondDate = Expression.Property(dateFilter, "SecondDate");
    
    var ge = Expression.GreaterThanOrEqual(
    	Expression.Convert(targetDate, firstDate.Type),
    	firstDate);
    
    var predicate = Expression.Lambda<Func<MyEntity, bool>>(
    	ge, changeInfo);
    result = result.Where(predicate);
