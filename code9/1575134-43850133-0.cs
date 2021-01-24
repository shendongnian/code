      var linqJoin = from j in junctions
                       join d in departments on j.DepartmentId equals d.Id
                       group new { j, d } by new { j.DepartmentId, d.Name } into g
                       select new DepartmentWithRoom
                       {
                           DepartmentId = g.Key.DepartmentId,
                           DepartmentName = g.Key.Name,
                           RoomIdList = g.Select(x => x.j.RoomId).ToList()
                       };
