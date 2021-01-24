    [DataContract()]
    public class Evaluation
    {
        private int _EstLaborOfficeId;
        private int _EstSequenceNumber;
        private long _IdNumber;
        [DataMember]
        public int EstLaborOfficeId
        {
            get { return _EstLaborOfficeId; }
            set { _EstLaborOfficeId = value; }
        }
        [DataMember(Order = 2)]
        public int EstSequenceNumber
        {
            get { return _EstSequenceNumber; }
            set { _EstSequenceNumber = value; }
        }
    }
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
