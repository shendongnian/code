    List<string> values = new List<string>();
    
    values.AddRange(tableA.Select(ta => ta.CompanyName).ToList());
    
    var tableBVals = tableB.Where(tb => !values.Contains(tb.CompanyName)).ToList();
    values.AddRange(tableBVals);
    
    var tableCVals = tableC.Where(tc => !values.Contains(tc.CompanyName)).ToList();
    values.AddRange(tableCVals);
    
    var tableDVals = tableD.Where(td => !values.Contains(td.ConsumerName)).ToList();
    values.AddRange(tableDVals);
