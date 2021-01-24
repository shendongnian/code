     public static void SyncData([QueueTrigger("backup")] string logMessage, TextWriter logger)
        {
            Console.WriteLine($"Start time:{DateTime.Now}");
            switch (logMessage.ToLower())
            {
                case "syncall":
                    SyncAll(logger);
                    break;
                case "syncbranches":
                    SyncBranches(logger);
                    break;
                case "synccustomers":
                    SyncCustomers(logger);
                    break;
                case "syncinventory":
                    SyncInventory(logger);
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }
            Console.Write($"Endtime:{DateTime.Now}");
    
        }
        [NoAutomaticTrigger]
        public static Task SyncAll(TextWriter log)
        {
    
            Console.WriteLine("SyncAll :"+DateTime.Now);
            return null;
            //await Task.Delay(10);
        }
    
        [NoAutomaticTrigger]
        public static Task SyncBranches(TextWriter log)
        {
            Console.WriteLine("SyncBranches :" + DateTime.Now);
            return null;
        }
    
        [NoAutomaticTrigger]
        public static Task SyncCustomers(TextWriter log)
        {
            Console.WriteLine("SyncCustomers :" + DateTime.Now);
            return null;
        }
    
        [NoAutomaticTrigger]
        public static Task SyncInventory(TextWriter log)
        {
            Console.WriteLine("SyncInventory :" + DateTime.Now);
            return null;
        }
