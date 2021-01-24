    foreach (var group in groupedList)
    {
       using(var db = new MyDbContext()){
         db.Events.AddRange(group);
         db.SaveChanges();
       }
    }
