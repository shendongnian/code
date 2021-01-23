    public class Consultant
    {
        public ObjectId Id { get; set; }
        public DateTime ComplementTime { get; set; }
        public IConsultantFutureWorkInfo FutureWorker { get; set; }
        public IConsultantFutureWorkInfo[] RecommendedWorkers { get; set; }
    }
    public class Salesman
    {
        public ObjectId Id { get; set; }
        public DateTime ComplementTime { get; set; }
        public ISalesmanFutureWorkInfo FutureWorker { get; set; }
    }
 
