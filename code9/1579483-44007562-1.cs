      public class AddFollowerJob
      {
          public static void Run() 
          { 
              AddFollower adf = new AddFollower();
              // do whatever you want here with adf
              // initialize API here
              adf.AddFollowerState(2, IInstaApi); 
              // handle results here
          }
      }
      RecurringJob.AddOrUpdate("addfollow", () => AddFollowerJob.Run(), "*/10 * * * *", TimeZoneInfo.Local, "default");
