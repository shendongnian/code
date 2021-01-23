     var list= allDoors.GroupBy(x=>new {Id=x.ControllerId ,Name=x.ControllerName})
                       .Select(x=>new AccessGroupControllerDoorEntity{
                               ControllerId=x.Key.Id,
                               ControllerName=x.Key.Name,
                               Doors = x.ToList()
                        }).ToList();
