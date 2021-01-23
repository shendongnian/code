     var results = (from t1 in context.AUMaterials
                          join t2 in context.AUModelMaterials
                          on new {t1.Col1, t1.Col2, t1.Col3 } equals
                              new { t2.Col1, t2.Col2, t2.Col3 }
                          where t1.ServiceRequestTypeId == serviceReqId && t1.SSStock.Quantity > 0 && t2.ModelId == modelId
                          select new { t1, t2}).ToList();
