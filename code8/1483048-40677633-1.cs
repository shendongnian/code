             var list= allDoors.GroupBy(x=>new {x.ControllerId ,Name=ControllerName},
                (key, group) => new AccessGroupControllerDoorEntity
                 { 
                    ControllerId=x.ControllerId ,
                    ControllerName=x.Key.ControllerName,
                    Doors = group.ToList()
                 }))
                .ToList();
