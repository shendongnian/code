    IEnumerable<DataRow> smallExchangeReport =  
        from ex in exchangeProgReport.AsEnumerable()
        where !string.IsNullOrEmpty(ex.comment)
        group ex by new { ex.siteName } into g
        select PopulateDataRow(
            smrTable,
            siteName: g.Key.siteName,
            exchangeCounter: g.Where(x => x.Prog1ToProg2Check == 1).Count(),
            descriptions: (from t in g.AsEnumerable()
                group t by new { t.comment, t.siteName } into grp
                select new Description {
                    title = grp.Key.comment,
                    numbers = grp.Select(x => x.comment).Count()
                }
            )
        );
