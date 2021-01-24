    public ActionResult Rooms()
            {
                using (RoomReservationEntities db = new RoomReservationEntities())
                {
                    var room_query = (from room in db.Rooms
                            join roomType in db.Room_Type
                            on room.RoomType_id equals roomType.RoomType_id
                            select new { room.Room_id, room.Room_name, roomType.RoomType, roomType.Room_rate }).ToList();
                    return Json(new { data = room_query }, JsonRequestBehavior.AllowGet);
                }
            }
