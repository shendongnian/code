    [DataContract]
    public class SecurityFault
    {
        private string operation;
        private string problemType;
        [DataMember]
        public string Operation
        {
            get { return operation; }
            set { operation = value; }
        }
        [DataMember]
        public string ProblemType
        {
            get { return problemType; }
            set { problemType = value; }
        }
    }
