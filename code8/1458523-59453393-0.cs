    using (var transaction = myDbContext.BeginTransaction())
    {
      InsertFirstThing();
      myDbContext.SaveChanges();
      
      InsertSecondThing();
      myDbContext.SaveChanges();
      
      if (EverythingWasSuccessful())
      {
        transaction.Commit();
      }
    }
