    private void RunMigrations()
        {
            Console.WriteLine("Starting migrations...");
            var configuration = new Configuration
            {
                TargetDatabase = new DbConnectionInfo(_connectionString, "System.Data.SqlClient")
            };
            var dbMigrator = new DbMigrator(configuration);
            dbMigrator.Update();
            Console.WriteLine("Migrations completed");
    
            //add your service here and do whatever you want.
        }
    
        private void Seed()
        {
            using (var MyContext = new MyContext(_connectionString))
            {
                Console.WriteLine("Seeding test data into database");
                //this is a custom seed method
                Initialize.Seed(_connectionString);
                Console.WriteLine("Seeding test data is complete");
                
                //add your service here and do whatever you want.
            }
        }
