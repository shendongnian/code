        public List<Table1> GetSqlJoinedDataViaDaper(int customerId)
        {
            var repo = new GenericRepository<T_LOOKUP>();
            var sql = @"select table1.ID Table1ID, table1.*,
                        table2.ID Table2ID, table2.*,
                        table3.ID Table3ID, table3.*
                        from dbo.Table1 table1 (nolock)
                        left outer join dbo.Table2 table2 (nolock) on table2.ID=n.FKTable2ID
                        left outer join dbo.Table3 table3 (nolock) on table3.ID=table1.FKTable3ID
                        where table1.CustomerID=@p1 ";
            var resultWithJoin = repo.QueryMultiple<Table1, Table2, Table3>(sql,
                new { p1 = 1, splitOn = "Table1ID,Table2ID,Table3ID" }).ToList();
            var retval = new List<Table1>();
            foreach (var item in resultWithJoin)
            {
                Table1 t1 = item.Item2; //After first split
                t1.Table2 = item.Item3; //After Table2ID split
                t1.Table3 = item.Item4; //After Table3ID split
                retval.Add(t1);
            }
            return retval;
        }
