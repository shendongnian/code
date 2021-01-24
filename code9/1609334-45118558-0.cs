    using (var dbContext = new IraniBotEntities())
     {
         var allRec= dbContext.Users;
         dbContext.Users.RemoveRange(allRec);
         dbContext.SaveChanges();
     }
