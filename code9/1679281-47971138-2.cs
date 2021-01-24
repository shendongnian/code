    var qry2 = (from p in db.Returns
                select new ReturnDto()
                { 
                    TranNo  = p.TranNo,
                    ExtItem = (from p1 in db.Items.Where(p2 => p2.ProductCode == p.ItemCode)
                               select qty(p1)).FirstOrDefault()
                })
                .ToList();
