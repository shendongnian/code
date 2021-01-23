    List<AccessGroupControllerDoorEntity> grouped = allDoors.GroupBy(e => e.ControllerId)
            .Select(group => new AccessGroupControllerDoorEntity
                           {
                                ControllerId = group.Key.Id,
                                ControllerName = group.Key.Name,
                                Doors = group.ToList() 
                           });
