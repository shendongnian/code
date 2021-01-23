    TblOrders
       .Join (
          TblOrderDetails, 
          t => t.Id, 
          d => d.OrderId, 
          (t, d) => 
             new  
             {
                t = t, 
                d = d
             }
       )
       .GroupBy (
          temp0 => 
             new  
             {
                Id = temp0.t.Id, 
                OrderNo = temp0.t.OrderNo, 
                OrderDate = temp0.t.OrderDate
             }, 
          temp0 => temp0.d
       )
       .OrderByDescending (g => g.Key.OrderNo)
       .Select (
          g => 
             new  
             {
                ID = g.Key.Id, 
                OrderNo = g.Key.OrderNo, 
                OrderDate = g.Key.OrderDate, 
                amount = g.Sum (x => x.Rate)
             }
       )
