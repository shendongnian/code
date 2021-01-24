     namespace rsDeployer.Common.SQLServerCommunication         
        {
           public class ConsumerClass
           {
               var profile = new RsProfile();
               var rsConnectionCreator = new RSDatabaseConnectionCreator(profile);
               var sqlConnection = rsConnectionCreator.CreateConnection(...Parameters here...);
           }
        }
