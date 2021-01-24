    [DataContract]
    public class EvaluationRequest
    {
        [DataMember]
        public string PeriodStart { get; set; }
    
        [DataMember]
        public string PeriodEnd { get; set; }
    } 
    [ServiceContract()]
    public interface IEvaluationWebService
    {
        [OperationContract]
        List<Evaluation> GetEvaluations(EvaluationRequest evaluationRequest);
    }
