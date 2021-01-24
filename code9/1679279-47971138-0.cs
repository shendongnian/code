    var qry2 = (from p in db.Returns
                select new ReturnDto()
                { 
                    TranNo  = p.TranNo,
                    ExtItem = (from p1 in db.Items.Where(p2 => p2.ProductCode == p.ItemCode)
                               select new ItemDto()
                               {
                                   Id = p1.Id,
                                   ItemCode = p1.ItemCode
                               })
                               .FirstOrDefault()
                })
                .ToList();
