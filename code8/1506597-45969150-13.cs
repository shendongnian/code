    using System;
    using System.Data.OracleClient;
    namespace TestCore
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Starting.\r\n");                      
                using (var _db = new OracleConnection("User Id=myUser;Password=myPassword;Data Source=MyOracleConnection"))
                {
                    Console.WriteLine("Open connection...");
                    _db.Open();
				    Console.WriteLine(  "Connected to:" +_db.ServerVersion);
				    Console.WriteLine("\r\nDone. Press key for exit");
				    Console.ReadKey();
			    }			
            }
        }
    }
