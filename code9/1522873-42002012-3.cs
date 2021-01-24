    public class DataParser
    {
        // to deserialize database from file
        public T ConstructItemDatabase<T>(string fileLocation)
        {
            var json = File.ReadAllText(fileLocation);
            return JsonConvert.DeserializeObject<T>(json);
        }
        // to serialize (save) database to a file
        public void SaveItemDatabaseToJson<T>(string fileLocation, T database)
        {
            var json = JsonConvert.SerializeObject(database);
            File.WriteAllText(fileLocation, json);
        }
    }
