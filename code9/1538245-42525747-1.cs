    var room = _db1Context.room;
    var roomDetails = _db2Context.RoomDetails;
    var roomSummary = _db3Context.RoomSummaries;
    var subtables = roomDetails.Join(roomSummary, rd=>ClientRoomId, rs=>rs.ClientRoomId, (roomDetails, summary)=>new {roomDetails.ClientRoomId, roomDetails, roomSummary});
    var rooms = room.Join(subtables, r=>r.Id, sub=>sub.ClientRoomId, (room, sub)=>
        new Room()
            {
                Id = room.Id,                                                      
                Name = room.DisplayName,                          
                Description = sub.roomDetail.Description,
                Status = sub.summary.Status,
                OnlineStatus = sub.summary.OnlineStatus,
                ServicePlan = sub.roomdetail.ServicePlan
                Incidents = room.Incident == null ? new List<Incident>() : room.Incident.ToList(),
                Devices = sub.roomDetail.Devices == null ? new List<Device>() : roomDetail.Devices.ToList()
            });
