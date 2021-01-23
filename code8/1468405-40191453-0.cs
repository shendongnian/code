    var query1 = (from mypdtlist in db.MyProductlist
                              join pdt in db.Product on mypdtlist.Product_ID equals pdt.ID
                              where mypdtlist.User_ID.Equals(UserID)
                              select new ViewModal
                              {
                                  ProductName = pdt.ProductName,
                                  CompanyName = pdt.CompanyName,
                                  DivisionName = pdt.DivisionName,
                                  Type = pdt.Type,
                                  Form = pdt.Form,
                                  Packing = pdt.Packing,
                                  MRP = pdt.MRP,
                                  DrugName = pdt.DrugName,
                                  ID = mypdtlist.ID
                              })
