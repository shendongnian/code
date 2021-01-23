    public interface IDbConnectionFactory {
        ///<summary>
        ///  Creates a connection based on the given database name or connection string.
        ///</summary>
        IDbConnection CreateConnection(string nameOrConnectionString);
    }
    public class Data : IData {
        private IDbConnectionFactory dbConnectionFactory;
        ISomeObjectFactory someObjectFactory;
        private string CONNECTION_STRING = "Connection string here";
        public Data(IDbConnectionFactory dbConnectionFactory, ISomeObjectFactory objectFactory) {
            this.dbConnectionFactory = dbConnectionFactory;
            this.someObjectFactory = objectFactory;
        }
        public List<ISomeObject> GetSomeObjects() {
            var objects = new List<ISomeObject>();
            //do some SQL stuff and return a data reader
            using (var connnection = dbConnectionFactory.CreateConnection(CONNECTION_STRING)) {
                using (var command = connnection.CreateCommand()) {
                    //configure command to be executed.
                    command.CommandText = "SELECT * FROM SOMEOBJECT_TABLE";
                    connnection.Open();
                    using (var reader = command.ExecuteReader()) {
                        while (reader.Read()) {
                            //...Logic to populate item
                            var someObject = someObjectFactory.Create(reader);
                            if (someObject != null)
                                objects.Add(someObject);
                        }
                    }
                }
            }
            return objects;
        }
    }
