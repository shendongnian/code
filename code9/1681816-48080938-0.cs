    var fourYearsAgo = DateTime.Now.AddYears(-4).Year;
    
    var dataWithoutGrouping = from m in MainData
                                  where m.CID == "334r" && m.STMTDT.Value.Year > fourYearsAgo
                                  join a in Adjustments
                                    on new {m.STMTDT, m.Stmtno} equals new {a.STMTDT, a.Stmtno} into grp
                                  from ja in grp.DefaultIfEmpty()
                                  select new {
                                                    Dt = m.STMTDT,
                                                    No = m.Stmtno,
                                                    Fee = m.PayAmount,
                                                    Adjustment = ja.Amount
                                                };
    
        var data = (from b in dataWithoutGrouping
                    group b by new {b.Dt, b.No }into grp
                    select new {
                       StatmentFee = grp.Sum(x => x.Fee),
                       StatementAdjustments = grp.Sum(x => x.Adjustment),
                       StatementDate = grp.Key.Dt,
                       StatementNo = grp.Key.No
                       }).ToList();
