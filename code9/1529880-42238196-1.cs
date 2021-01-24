    public class FileEntityRetriever<T> : IFileEntityRetriever
    {
        IStreamDeserializer<T> deserializer;
        
        public FileEntityRetriever(IStreamDeserializer<T> deserializer)
        {
            this.deserializer = deserializer;
        }
    
        public T GetFromFile(string path, IStreamDeserializer<T> deserializer)
        {
            using (var stream = GetFileStream(path))
            {
                return deserializer.Read(stream);
            }
        }
    
    }
