    var list=context.Batch.GroupBy(x=>new{x.ItemName,x.ItemNo})
                          .Select(x=> new SampleModel{
                                  ItemName=x.Key.ItemName,
                                  ItemNo=x.Key.ItemNo,
                                  Group1=x.Where(y=>y.GroupName=="Group1").First().ItemQty, 
                                  Group2=x.Where(y=>y.GroupName=="Group2").First().ItemQty, 
                                  Group3=x.Where(y=>y.GroupName=="Group3").First().ItemQty, 
                                  Group4=x.Where(y=>y.GroupName=="Group4").First().ItemQty, 
                           }).ToList();
