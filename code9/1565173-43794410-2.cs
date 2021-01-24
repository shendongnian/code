    public class Log<T>
        where T : class, new()
    {
        public Log() { }
        public Log(LogDb logDb)
        {
            Data = licensingLogDb.OldDataJson.Deserialize<T>();
            Id = licensingLogDb.Id;
        }
        public long Id { get; set; }
        public T Data { get; set; }
        public LogDb ToDb()
        {
            string dataJson = Data.Serialize();
            return new LogDb
            {
                DataJson = dataJson,
                Id = Id
            };
        }
    }
