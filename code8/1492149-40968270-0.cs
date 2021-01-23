        Table1.GroupJoin(Table2,
                        x => x.ID,
                        y => y.ID,
                        (tbl1, tbl2) => new {Table1=tbl1, Table2 =tbl2.DefaultIfEmpty()})
                        .SelectMany(
                        tbl => tbl.Table2.Where(t2 => t2.example == null).Select(x => new
                        {
                            id= tbl.Table1.ID,
                            test = tbl.Table1.Test,
                            test2 = tbl.Table2.Test
                        }))ToList();
