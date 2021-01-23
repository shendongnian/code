    List<Owner> list = DBContext.Owners.Where(to => to.OwnerID == ownerParameter).ToList();
    
    HaveList = list.Select(t => new Owner()
                        {
                            Model = t.Transport.Model,
                            Brand = t.Transport.Brand,
                            PlateNo = t.Transport.PlateNo
                        }).ToList();
