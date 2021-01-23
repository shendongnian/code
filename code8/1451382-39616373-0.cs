            var result = (from o in query 
                          where o.OwnerID==OwnerParameter
                         select new OwnerModel
                         {
                             Model=o.Transport.Model,
                             Brand=o.Transport.Brand
                         }).ToList();
