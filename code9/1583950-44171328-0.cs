    db.table1
        .Join(db.table1, a => a.ClientNum, b => b.ClientNum, (a, b) => new { T1 = a, T2 = b })
         .Where(o =>
                    (o.T2.CreateDate < o.T1.CreateDate
                    && o.T2.CreateDate > o.T1.CreateDate.AddYear(-1))
                    ||
                    (o.T1.CreateDate < o.T2.CreateDate
                    && o.T1.CreateDate > o.T2.CreateDate.AddYear(-1))
            ).ToList();
