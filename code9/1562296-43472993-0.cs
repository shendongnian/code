    targetViewModel.TargetList                      
        // Group by unique analyte/method/instrument   
        .GroupBy(x => new { x.AnalyteID, x.AnalyteName, x.MethodID, x.MethodName, x.InstrumentID, x.InstrumentName }) 
            // Select all attributes and collect units together in a list                   
            .Select(g => new TargetView
            {
                id = g.Max(i => i.id),
                AnalyteID = g.Key.AnalyteID,
                AnalyteName = g.Key.AnalyteName,
                MethodID = g.Key.MethodID,
                MethodName = g.Key.MethodName,
                InstrumentID = g.Key.InstrumentID,  
                InstrumentName = g.Key.InstrumentName,
                TargetMean = g.Max(i => i.TargetMean),
                UnitID = g.Max(i => i.UnitID),
                UnitDescription = g.Max(i => i.UnitDescription),
                // only extract units when target mean is 0                   
                Units = g.Where(y => y.TargetMean == 0) 
                    .Select(c => new Unit { ID = c.UnitID, Description = c.UnitDescription }).ToList() 
    }).ToList();
