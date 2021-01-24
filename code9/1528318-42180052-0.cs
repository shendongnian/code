    var retval = (from a in BackOrderItems where a.Model == "UUTTIISJWW"
                 group a by a.ServiceCode into grp1
                 select new
                        {
                            Code = grp1.Key, 
                            Count = grp1.Count()
                        })
                 .ToList();             
