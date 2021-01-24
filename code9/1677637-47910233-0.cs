    var union =  
         (from lot in parkingLots
         where lot.status == true
         orderby lot.PricePerHour // don't forget ordering
         select new {
               ID = lot.parkingLotID, 
               lot.address, lot.latitude, lot.longitude, lot.status})
        .Union(from pub in publicParkings
         where pub.status==true
         orderby pub.PricePerHour // don't forget ordering
         select new {
               ID = pub.publicParkingID, 
               pub.address, pub.latitude, pub.longitude, pub.status});
