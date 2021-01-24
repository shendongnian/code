    public class MongoObject<T>
    {
        [BsonId]
        private ObjectId _objectId;
        [BsonElement]
        public T Element { get; }
    
        public MongoObject(T element)
        {
            Element = element 
        }
    }
