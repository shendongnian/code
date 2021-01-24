    var existingCounts = joinData.Select(r => new DySystemCountDto
                {
                    ResourceCountId = r.ResourceCountId,
                    Quantity = r.ResourceCount.Quantity,
                    DySystemId =  r.DySystemId
                }).ToList();
   
