    public List<Room> All()
    {
        using (HotelEntities db = new HotelEntities())
        {
            var result = from room in db.Rooms
                         select new Room
                         {
                             room.RoomNumber,
                             room.Id,
                             room.RoomType
                         };
            return result.ToList();
        }
    }
