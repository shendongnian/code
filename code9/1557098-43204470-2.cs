    public List<Room> All()
    {
        using (HotelEntities db = new HotelEntities())
        {
            var items = from room in db.Rooms
                         select new Room
                         {
                             room.RoomNumber,
                             room.Id,
                             room.RoomType
                         }.ToList();
            var result = items.Select(i=>
                           new Room  {
                             RoomNumber = i.RoomNumber,
                             Id  = i.Id,
                             RoomType  = i.RoomType
                         }).ToList();
            return result;
        }
    }
