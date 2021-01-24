    class Program
    {
        static void Main(string[] args)
        {
            //Run producer  thread
            Task.Run(new Action(ReadDataFromTable));
            //Run consumer  thread
            Task.Run(new Action(WriteDataToText));
    
            Console.Read();
        }
    
        public static ConcurrentQueue<TModel> entitiesQueue = new ConcurrentQueue<TModel>();
        //This tag point out whether the read process is down
        public static bool ReadTableFinished = false;
        public static void ReadDataFromTable()
        {
            do
            {
                var entities = new List<TModel>();
                var queryResult = table.ExecuteQuerySegmented(new TableQuery<TModel>(), token);
                entities.AddRange(queryResult.Results);
                count = count + 1000;
    
                Console.WriteLine("{0} records retrieved", count);
    
                //Save entites to the queue
                foreach (TModel entity in entities)
                {
                    entitiesQueue.Enqueue(entity);
                }
                token = queryResult.ContinuationToken;
            }
            while (token != null);
    
            ReadTableFinished = true;
        }
    
        public static void WriteDataToText()
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                //header
                writer.Write("PartitionKey|RowKey|Timestamp|Id|");
                writer.WriteLine();
    
                do
                {
                    TModel entity = null;
                    //Read and remove entity from queue 
                    entitiesQueue.TryDequeue(out entity);
    
                    if (entity != null)
                    {
                        //Write data to text file
                        writer.Write("\"" + entity.PartitionKey + "\"|\"" + entity.RowKey + "\"|" + entity.Timestamp + "|" + entity.Id);
                        writer.WriteLine();
                    }
                    else
                    {
                        //If all the entities are read out from the table and now there is no entities in the queue, we will break this loop and exit current thread.
                        if (ReadTableFinished)
                        {
                            break;
                        }
                    }
                }
                while (true);
                writer.Dispose();
            }
        }
    }
