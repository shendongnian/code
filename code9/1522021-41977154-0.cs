    var results = table1.Where(t1 => table2.Where(
            t2 =>
                table3.Where(
                        t3 =>
                            table4.Where(t4 => t4.FkColumnD == 1)
                                .Select(t4 => t4.ColumnC)
                                .Contains(t3.FkColumnC))
                    .Select(t3 => t3.ColumnB)
                    .Contains(t2.FkColumnB) && !t2.FkColumnE.HasValue && t2.ColumnF == 0)
        .Select(t2 => t2.FkColumnA)
        .Contains(t1.ColumnA));
