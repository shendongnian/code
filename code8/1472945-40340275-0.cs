            String connectionString = "mongodb://your_address_here";
            
            var client = new MongoClient(connectionString);
            
            var database = client.GetDatabase("db_name_from_which_you_need_collections");
            
            var cnames = database.ListCollections();
            
            var allNames = cnames.ToList();
            foreach(var x in allNames)
            {
                Console.WriteLine(x.ToString());
                
            }
