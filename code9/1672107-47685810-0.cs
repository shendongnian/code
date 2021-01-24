    var query = context.DataTable
           .Where(i => 
               queryList.Any(item => 
                  i.ValueName == item.ValueName 
                  && i.Symbol == item.Symbol 
                  && i.Days == item.Days))
           .ToList();
