    var rslt = (from t in context.Set<SUB_Transactions>()
                where t.TransactionID > query.Index // invert order of filter
                   && t.UpdateDate > query.LastUpdate 
                order by t.TransactionID // you can orderby here
                select t.TransactionID) // remove anonymous object
               .Take(query.Amount)
               .AsNoTracking() // you won't be changing IDs so no need to track them
               .ToList();
