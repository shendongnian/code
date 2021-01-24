     var result = from department in Departments
                         join junction in Junctions on department.DepartmentId equals junction.DepartmentId into rooms
                         select
                             new DepartmentWithRoom
                                 {
                                     DepartmentId = department.DepartmentId,
                                     DepartmentName = department.DepartmentName,
                                     RoomIdList = rooms.Select(r => r.RoomId).ToList()
                                 };
