        using (var ctx = new TestDBEntities()) {
            // fill data table with your ids
            var dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));                    
            for (int i = 0; i < 75000; i++) {
               dt.Rows.Add(i);
            }
            // make a query
            var result = ctx.Database.SqlQuery<BigTable>("select BT.* from BigTable BT inner join @IDS I on BT.CodeID = I.ID",
                new SqlParameter("IDS", SqlDbType.Structured)
                {                        
                    // name of type you created in step 1
                    TypeName = "dbo.IntHashSet",
                    Value = dt
                }).ToArray();
        }
