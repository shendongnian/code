    using System;
    using System.Data.OracleClient;
    namespace TestCore
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Start.");                      
                Console.WriteLine("create OracleConnection object...");
                using (var _db = new OracleConnection("User Id=myUser;Password=myPassword;Data Source=MyOracleConnection"))
                {
                    Console.WriteLine("Open connection...");
                    _db.Open();
				    Console.WriteLine( _db.ServerVersion);
				    Console.WriteLine("Done.Press key for exit");
				    Console.ReadKey();
			    }			
            }
        }
    }
