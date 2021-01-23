    var query = from t1 in table_1
                join t2 in table_2 on t1.col1 equals t2.col1
                where t1.EmployeeId == EmployeeId
                group new { t1, t2 } by t1.col2 into grouped
                orderby grouped.Count() descending
                select new { Column1 = grouped.Key, Column2 = grouped.Sum(g=>g.t2.col4) };
    var generatedSql = query.ToString(); // Here you will see a query that brings all records
    
    var records = query.Take(10);
    generatedSql = query.ToString(); // Here you will see it taking only 10 records
    // point x
    var xQuery = records.Select(a => a.Column1);
    generatedSql = xQuery.ToString(); // Here you will see only 1 column in query
    // Still nothing has been executed to DB at this point
    var x = xQuery.ToArray(); // And that is what will be executed here
    
    // Now you are before second execution
    var yQuery = records.Select(a => a.Column2);
    generatedSql = yQuery.ToString(); // Here you will see only the second column in query
    // Finally, second execution, now with the other column
    var y = yQuery.ToArray();
