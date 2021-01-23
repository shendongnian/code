    var balancesheet = (from a in bs.Rows
                                where a.RowType == "Section"
                                &&
                                a.Rows.Count > 0 
                                &&
                                (a.Rows.Where(x => x.RowType == "Row")) != null 
                                select new
                                {                                    
                                    ReportCells =   a.Rows
                                                    .SelectMany( x=>
                                                    {
                                                        return x.Cells.Where(s => s.Attributes != null);
                                                    }).ToList()
                                        
                                }
                                ).ToList();
    List<ReportCell> allCells = balancesheet.Where(z => z.ReportCells.Count > 0).SelectMany(x =>
          {
              return x.ReportCells;
          }).ToList();
    List<BalanceSheet> allBalanceSheetInfo = new List<BalanceSheet>();
            for(int i = 0; i < allCells.Count; i += 3)
            {
                allBalanceSheetInfo.Add(new BalanceSheet()
                {
                    
                    AccountId = allCells.ElementAt(i).Attributes.FirstOrDefault() != null ? new Guid(allCells.ElementAt(i).Attributes.FirstOrDefault().Value) : Guid.Empty,
                    AccountName = allCells.ElementAt(i).Value,
                    Amount = Decimal.Parse(allCells.ElementAt(i + 1).Value)
                });
            }
