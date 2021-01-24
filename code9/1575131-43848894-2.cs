    var result= context.Departments
                       .Where(d=>d.Rooms.Any())// I guess you need only those departments that have rooms
                       .Select(d=>new DepartmentWithRoom{
                                      DepartmentId= d.Id,
                                      DepartmentName=d.Name,
                                      RoomIdList=d.DeparmentRoomJunction.Select(r=>r.RoomId).ToList()
                                  }); 
