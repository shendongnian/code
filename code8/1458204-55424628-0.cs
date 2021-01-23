[DataContract(Namespace = "Microsoft.ServiceBus.Messaging")]
public class EventData
{
    [DataMember(Name = "SequenceNumber")]
    public long SequenceNumber { get; set; }
    [DataMember(Name = "Offset")]
    public string Offset { get; set; }
    [DataMember(Name = "EnqueuedTimeUtc")]
    public string EnqueuedTimeUtc { get; set; }
    [DataMember(Name = "Body")]
    [NullableSchema]
    public foo Body { get; set; }
}
