    foreach (var Entity in EntitySet.Where(e => e != null))
    {
        var values = Enumerable.Range(0, iCols)
            .Select(ii => props[ii]?.GetValue(Entity)).Where(v => v !=  null);
        // .... write in the sheet
    } 
