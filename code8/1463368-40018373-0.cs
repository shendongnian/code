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
                                          StorageName = st.Name,
                                          UserId = o.UserId,
                                          CustomerName = c.NameSurname,
                                          CustomerTelephone = c.Telephone,
                                          DateEntry = o.DateEntry,
                                          DateUpdate = o.DateUpdate,
                                          DateRelease = o.DateRelease,
                                          Price = o.Price,
                                          StatusName = sn.Name,
                                          FollowCode = o.FollowCode,
                                          DeviceBrand = o.DeviceBrand,
                                          DeviceModel = o.DeviceModel,
                                          DeviceSerialNumber = o.DeviceSerialNumber,
                                          DeviceComplaint = o.DeviceComplaint,
                                          Comment = o.Comment,
                                          Details = d.Select<OrderDetails,VMOrderEditDetails>(x => /*your convertion*/).ToList()
                                      }).ToList();
