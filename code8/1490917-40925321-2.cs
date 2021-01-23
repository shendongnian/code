    var list=context.Batch.GroupBy(x=>new{x.ItemName,x.ItemNo})
                          .Select(x=> new SampleModel{
                                  ItemName=x.Key.ItemName,
                                  ItemNo=x.Key.ItemNo,
                                  Group1=x.Where(y=>y.GroupName=="Group1").FirstOrDefault()==null 0:x.Where(y=>y.GroupName=="Group1").FirstOrDefault().ItemQty, 
                                  Group2=x.Where(y=>y.GroupName=="Group2").FirstOrDefault()==null 0:x.Where(y=>y.GroupName=="Group2").FirstOrDefault().ItemQty,  
                                  Group3=x.Where(y=>y.GroupName=="Group3").FirstOrDefault()==null 0:x.Where(y=>y.GroupName=="Group3").FirstOrDefault().ItemQty, 
                                  Group4=x.Where(y=>y.GroupName=="Group4").FirstOrDefault()==null 0:x.Where(y=>y.GroupName=="Group4").FirstOrDefault().ItemQty,  
                           }).ToList();
