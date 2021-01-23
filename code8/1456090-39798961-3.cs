    var readMethodBase = typeof(EntityUtils).GetMethod("ReadSingleResult", new[] { typeof(DbContext), typeof(DbDataReader) });
    
    foreach (var className in classNames)
    {
        // ...
        var readMethod = readMethodBase.MakeGenericMethod(classType);
        var result = ((IEnumerable)readMethod.Invoke(null, new object[] { dbContext, dbReader }))
            .Cast<dynamic>()
    	    .ToList();
        // ...
        dbReader.NextResult();
    }
