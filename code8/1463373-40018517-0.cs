     Details = DB.OrderDetail.Where(x => x.OrderId == o.Id).Select(x=>new VMOrderEditDetails{
        Id = x.Id,
        OrderId =x.OrderId,
        SparePartName =x.Sp=arePartName,
        SparePartPrice =x.SparePartPrice,
        Labor=x.Labor,
        Total=x.Total,
        Comment=x.Comment
    }).ToList()
