    var List = (from t1 in dbContext.table1
                      join t2 in dbContext.table2 on t1.ID equals t2.ID
                      join t3 in dbContext.table3 on t1.ID equals t3.ID
                      select new
                      {
                       //t1.DesiredColumnName,
                       //t2.DesiredColumnName,
                       //t3.DesiredColumnName,
                       //so on
                      }).Distinct().ToList();
