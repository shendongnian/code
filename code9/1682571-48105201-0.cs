    public class Campus : IErrorMessage {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public string ErrorMessage { get; set; }
    }
