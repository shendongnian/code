    public class ClientSampleResponse : IPacket
    {
       public string Name { get; set; }
       public string Lastname { get; set; }
       public string Address { get; set; }
       public void Execute<T>(T client)
       {
           var method = typeof(T).GetMethod("Send");
           method.Invoke(client, new object[] { this });
       }
