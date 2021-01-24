     public static IQueryable<TableJoinResult> byRecID(Guid recID, MyContext DBContext)
      {
          return (from i1 in DBContext.Table1
                 join j1 in DBContext.Table2 on i1.GroupID equals j1.GroupID
                 where i1.RecID.Equals(RecID)
                 select new TableJoinResult { Table1= i1, Table2 = j1 }).SingleOrDefault();
      }
