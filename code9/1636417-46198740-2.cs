    (from Room in PMSdb.Room_Tbl
                join Res in PMSdb.Reservation_Tbl on
                Room.Room_ID equals Res.Room_ID
                into ej
                from Res in ej.DefaultIfEmpty()
                select new { room = Room, res = Res)
                .Where(x => x.Res == null)
                .Select(x => new {
                                 Room = x.room.Room_Number,
                                 Room_type = x.room.Room_Type_Code,
                                 Features = x.Room_Features.Split(new char[] {','})
                                    .Select(y => PMSdb.Room_Features_Tbl.Where(z => z.Room_Features_ID.ToString() == y).FirstDefault())
                                    .ToList() 
                }).ToList();
