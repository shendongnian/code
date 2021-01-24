    var query = _db.WorkOrders.AsQueryable();
    if(activeInactive != ActiveInactiveEnum.All)
         query = query.Where(i => i.IsActive.Value == (activeInactive == ActiveInactiveenum.Active));
    var workOrders = query.Select(i => new workOrderViewModel{
                           Id = i.Id,
                           Title = i.Title
                       });
