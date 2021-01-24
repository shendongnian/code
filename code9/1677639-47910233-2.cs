    var union =  
         (from lot in parkingLots
         where lot.status == true
         orderby lot.PricePerHour // don't forget ordering
         select new ParkingData {
               ID = lot.parkingLotID, 
               Address = lot.address, 
               Latitude = lot.latitude, 
               Longitude = lot.longitude, 
               Status = lot.status})
        .Union(from pub in publicParkings
         where pub.status==true
         orderby pub.PricePerHour // don't forget ordering
         select new {
         select new ParkingData {
               ID = pub.publicParkingID, 
               Address = pub.address, 
               Latitude = pub.latitude, 
               Longitude = pub.longitude, 
               Status = pub.status});
