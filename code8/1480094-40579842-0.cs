    public abstract class ItemBase<T> where T : new()
    {
        public abstract string table_name { get; }
    
        protected internal T Read(int id)
        {
            var query = $@"SELECT * FROM {table_name} WHERE id = {id}";
            //var itemList = IRead(query);
            Console.WriteLine(query); //Did this as console output for testing
            return new T(); // temList.FirstOrDefault();
        }
    
        protected internal List<T> Read(int startId, int limit, string orderBy = "id", string order = "ASC")
        {
            string query = $@"SELECT * FROM {table_name} WHERE id >= {startId} ORDER BY {orderBy} {order} LIMIT {limit}";
            Console.WriteLine(query); //Console output for testing
            return null;
            //return IRead(query);
        }
    }
