    public class ClientContext19 : CallTrackingDbContext
    {
      ...
      public override void OnModelCreating(DbModelBuilder dmb)
      {
        dmb.Entity<Phone>()
          .Map<Phone19>(m => m.Requires("discriminator").HasValue("Phone19"));
      }
    } 
