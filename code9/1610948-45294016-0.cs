    [Serializable()]
    public class Config
    {
        public string DeviceId { get; set; }
        public string Name { get; set; }
        public int Length { get; set; }
        
    }
    using (Stream testFileStream = File.Create(pathString)) // Serialization code
    {
        BinaryFormatter serializer = new BinaryFormatter();
        serializer.Serialize(testFileStream, config);
        testFileStream.Close();
    }
    using (Stream testFileStream = File.OpenRead(pathString))
    {
        BinaryFormatter deserializer = new BinaryFormatter();
        config = (Config)deserializer.Deserialize(testFileStream);
        testFileStream.Close();
    }
