    [DataContract]
    public class DemoMessage
    {
        [DataMember]
        public string Title { get; set; }
    }
    wc.Headers["Content-Type"] = "application/atom+xml;type=entry;charset=utf-8";
    MemoryStream ms = new MemoryStream();
    DataContractSerializer serializer = new DataContractSerializer(typeof(DemoMessage));
    serializer.WriteObject(ms, new DemoMessage() { Title = messageBody });
    wc.UploadString(sendAddress, "POST",System.Text.UTF8Encoding.UTF8.GetString(ms.ToArray()));
