    using (var context = new YourContext())
    {
         context.UpdateRange(yourModifiedEntities);
   
         // or the followings are also valid
         //context.UpdateRange(yourModifiedEntity1, yourModifiedEntity2, yourModifiedEntity3);
        //context.YourEntity.UpdateRange(yourModifiedEntities);
        //context.YourEntity.UpdateRange(yourModifiedEntity1, yourModifiedEntity2,yourModifiedEntity3);
                
        context.SaveChanges();
      }
