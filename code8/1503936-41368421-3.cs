    public class Consultant
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonConverter(typeof(ObjectIdConverter))]
        public ObjectId Id { get; set; }
        [BsonElement("complementTime")]
        public DateTime ComplementTime { get; set; }
        [BsonElement("futureWorker")]
        public IConsultantFutureWorkInfo FutureWorker { get; set; }
        [BsonElement("recommendedWorkers")]       
        public IConsultantFutureWorkInfo[] RecommendedWorkers { get; set; }
    }
    public class Salesman
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonConverter(typeof(ObjectIdConverter))]
        public ObjectId Id { get; set; }
        [BsonElement("complementTime")]
        public DateTime ComplementTime { get; set; }
        [BsonElement("futureWorker")]
        public ISalesmanFutureWorkInfo FutureWorker { get; set; }
    }
 
