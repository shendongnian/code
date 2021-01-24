     namespace rsDeployer.Common.SQLServerCommunication         
        {
           public class ConsumerClass
           { 
               public void QueryExecution(string SQLQuery)
               {
                 
               var profile = new RsProfile();
               var rsConnectionCreator = new RSDatabaseConnectionCreator(profile);
                   using(var sqlConnection = rsConnectionCreator.CreateConnection(...Parameters here...)){
                          SqlCommand command = new SqlCommand(SQLQuery, sqlConnection );
                          
                    }
                    var file = new StreamWriter(@"D:\Project\rsDeployer\ImportedQuery.txt");
                          file.WriteLine(command);
                          file.Close();
               }
           }
        }
