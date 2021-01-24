    public List<Room> All()
    {
        using (HotelEntities db = new HotelEntities())
        {
            var result = from room in db.Rooms
                         select new Room
                         {
                             RoomNumber = room.RoomNumber,
                             Id  = room.Id,
                             RoomType  = room.RoomType
                         };
            return result.ToList();
        }
    }
