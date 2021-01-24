    private void updateGraph(PhysicalObjectDto physicalObjectDto, IList<PhysicalObject> oldPhysicalObjects, MyDbContext dbContext, int storageRequestId, HashSet<int> existingIds, PhysicalObject parent = null)
        {
            if (physicalObjectAddEditDto.Id == 0)
            {
                PhysicalObject po = new PhysicalObject
                {
                    Id = physicalObjectAddEditDto.Id,
                    Title = physicalObjectAddEditDto.Title,
                    StorageRequestId = storageRequestId,
                    Parent=parent
                };
                dbContext.PhysicalObjects.Add(po);
          
                parent = po;
            }
            else
            {
                var po = oldPhysicalObjects.FirstOrDefault(x => x.Id == physicalObjectAddEditDto.Id);
                po.Title = physicalObjectAddEditDto.Title;
                po.StorageRequestId = storageRequestId;
                po.Parent = parent;
                dbContext.Entry(po).CurrentValues.SetValues(po);
                parent = po;
            }
            existingIds.Add(parent.Id);
            foreach (var subPhysicalObject in physicalObjectAddEditDto.SubPhysicalObjects)
            {
                updateGraph(subPhysicalObject, oldPhysicalObjects, dbContext, mailRoomRequestId, existingIds, parent);
            }
        }
