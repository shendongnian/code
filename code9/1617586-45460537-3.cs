    String ColumnName = "DateTimeInsert";
    DbSet<Log> oDbSet = _uow.DbContext.Set<Log>();
    Array DistinctValues;
    if (typeof(Log).GetProperty(ColumnName) != null)
      {
      DistinctValues = (await oDbSet.GetDistinctValuesForProperty(ColumnName)).ToArray();
      }
    else
      {
      DistinctValues = new object[0];
      }
