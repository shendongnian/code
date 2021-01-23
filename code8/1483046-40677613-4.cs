    List<AccessGroupControllerDoorEntity> grouped = allDoors.GroupBy(e => e.ControllerId)
            .Select(group => new AccessGroupControllerDoorEntity
                           {
                                DeviceControllerId = group.Key.Id,
                                DeviceControllerName = group.Key.Name,
                                Doors = group.ToList() 
                           });
