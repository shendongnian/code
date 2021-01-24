    public class DataStore
    {
        public long ElapsedTicks;            
        private string DataFilePath;
        public static DataStore Load(string dataFilePath)
        {
            DataStore dataStore;
            try
            {
                var serializer = new XmlSerializer(typeof(DataStore));
                using (StreamReader reader = File.OpenText(dataFilePath))
                {
                    dataStore = (DataStore)serializer.Deserialize(reader);
                }
            }
            catch
            {
                dataStore = new DataStore();
            }
            dataStore.DataFilePath = dataFilePath;
            return dataStore;
        }
        public void Save()
        {
            var serializer = new XmlSerializer(typeof(DataStore));
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            using (StreamWriter writer = File.CreateText(DataFilePath))
            {
                serializer.Serialize(writer, this, ns);
            }
        }
    }
