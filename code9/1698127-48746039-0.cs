    public int BookingsCount()
    {
        int count = 0;
        try
        {
            using (var context = new HotelContext()) 
            { 
                var sql ="SELECT COUNT(*) FROM Bookings WHERE ROOMID=" + this.RoomId;    
                count = context.Database.SqlQuery<int>(sql).First(); 
            }
        } catch (Exception ex)
        {
            // Log your error, count will be 0 by default
        }
        return count;
    }
