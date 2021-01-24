     var oldPhysicalObjects = dbContext.PhysicalObjects.Where(x => x.StorageRequestId== storageRequestId).ToList();
     var existingIds = new HashSet<int>();
     foreach (var item in newGraphDto.PhysicalObjects.ToList())
       {
         updateGraph(item, oldPhysicalObjects, dbContext, storageRequestId,existingIds);
       }
     var posToDelete = oldPhysicalObjects.Where(x => existingIds.All(e => e != x.Id)).ToList();
     dbContext.PhysicalObjects.RemoveRange(posToDelete);
     dbContext.SaveChanges();
    
