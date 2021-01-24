      //Returns IDs
           var bookingIds = tbl_bookings
                 .Where(b => b.ReleaseDate <= startDate && b.ReleaseDate >= endDate
                     || (b.ReleaseDate < endDate && b.ReleaseDate >= endDate)
                     || (b.ReleaseDate <= startDate && b.ReleaseDate >= endDate))
                 .Select(b => b.Id);
      
      //Returns anonymous object list containing all records
      //with an ID not found in previous result set
           var bookings = tbl_bookings.Where(b => !bookingIds.Contains(b.Id))
                 .Select(b => new { ID = b.Id, CoopName = b.Id, coopCPN = b.Id })
                 .ToList();
