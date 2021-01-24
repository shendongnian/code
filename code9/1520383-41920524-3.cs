    [MessageContract]
    public class Evaluation
    {
        private int _EstLaborOfficeId;
        private int _EstSequenceNumber;
        private long _IdNumber;
        [MessageBodyMember]
        public int EstLaborOfficeId
        {
            get { return _EstLaborOfficeId; }
            set { _EstLaborOfficeId = value; }
        }
        [MessageBodyMember]
        public int EstSequenceNumber
        {
            get { return _EstSequenceNumber; }
            set { _EstSequenceNumber = value; }
        }
    }
    [MessageContract]
    public class EvaluationList
    {
         [MessageBodyMember]
         public List<Evaluation> Values {get;set}
    }
    [ServiceContract()]
    public interface IEvaluationWebService
    {
        [OperationContract]
        EvaluationList GetEvaluations(EvaluationRequest evaluationRequest);
    }
