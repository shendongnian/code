        List<VMOrderEdit> OrderEditObj = (from o in DB.Orders
                                          join sn in DB.OrderStatusName on o.Status equals sn.Id
                                          join st in DB.Storages on o.StorageId equals st.Id
                                          join c in DB.Customers on o.CustomerId equals c.Id
                                          join d in DB.OrderDetails on o.Id equals d.OrderId into d 
                                          where o.Id == Id
                                          select new VMOrderEdit()
                                          {
                                              Id = o.Id,
                                              StorageId = o.StorageId,
                                              //All the other properties
                                              Comment = o.Comment,
                                              Details = d.Select(x => new VMOrderEditDetails{ /*your convertion*/ }).ToList()
                                          }).ToList();
