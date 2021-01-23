    public JsonDatastore : IDataStore
    {
        private readonly string dataFile;
        private readonly IList<MyModel> data;
        public Datastore(string dataFile)
        {
            this.dataFile = dataFile;
            this.data = JsonConvert.DeserializeObject<IList<MyModel>>(File.ReadAllText(dataFile));
        }
        public IQueryable<MyModel> Get()
        {
            return this.data.AsQueryable();
        }
        public void Add(MyModel model)
        {
            // If you want a lock free implementation you may consider
            // an algorithm which will only notify some underlying thread
            // that a change has been made to the underlying structure and
            // it will take care of saving those changes to the file system
            // This way it is guaranteed that only one thread is writing
            // to the file while the changes can be made in memory quite fast
            // (using a ConcurrentBag<T> instead of a list for example)
            lock (this)
            {
                // Make sure that only one thread is updating the file
                this.data.Add(model);
                string json = JsonConvert.SerializeObject(this.data);
                File.WriteAllText(this.dataFile, json);
            }
        }
    }
