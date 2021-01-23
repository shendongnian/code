    private void CleanupTable<T, U>(DbSet<T> dbSet, CleanupModel.Tables table, DbSet<U> lastDbSet, dynamic removedRec) where T : class where U : class
    {
        ParameterExpression tpe = Expression.Parameter(typeof(T));
        Expression idProp = Expression.Property(tpe, typeof(T).GetProperty(GetIdProperty(lastDbSet)));
        Expression constIdProp = Expression.Constant(removedRec.GetType().GetProperty(GetIdProperty(lastDbSet)).GetValue(removedRec, null), typeof(int));
        Expression completeExpression = Expression.Equal(idProp, constIdProp);
    
        Expression<Func<T, bool>> expression = Expression.Lambda<Func<T, bool>>(completeExpression, tpe);
        List<T> removedRecs = dbSet.Where(expression).ToList();
    
        removedRecs.ForEach(rec =>
        {
            dynamic nextSet = GetNextSet(table);
            if (nextSet == null)
            CleanupTable(nextSet, GetNextTable(table), dbSet, rec);
    
            dbSet.Remove(rec);
            reportHelper.ReportSuccess(table, ReportHelper.ReportReasons.Linked, rec);
        });
    }
