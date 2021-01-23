    [DataContract]
    [KnownType(typeof(CreateCommand))]
    [KnownType(typeof(DeleteCommand))]
    public class BaseCommand
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public string TenentName { get; set; }
    }
    [DataContract]
    public class CreateCommand : BaseCommand
    {
        [DataMember]
        public string Data { get; set; }
    }
    [DataContract]
    public class DeleteCommand : BaseCommand
    {
        [DataMember]
        public string SomeOtherData { get; set; }
    }
