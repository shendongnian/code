    var data = dbContext.tableA
                        .where(a => a.ID == rowID)
                        .Select(tableA=> new 
                        {
                           firstColumn = tableA.FirstColumn,
                           tableC = tableA.SelectMany(tableB=>tableB.TableC),
                        }.SingleOrDefault();
