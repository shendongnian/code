             var list= allDoors.GroupBy(x=>new {x.ControllerId ,Name=ControllerName},
                (key, group) => new AccessGroupControllerDoorEntity
                 { 
                    ControllerId=Key.ControllerId ,
                    ControllerName=Key.ControllerName,
                    Doors = group.ToList()
                 }))
                .ToList();
