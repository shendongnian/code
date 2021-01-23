    [ServiceContract(Namespace = "")]
    [XmlSerializerFormat]
    public interface IHelloWorldService
    {
        [OperationContract]
        [WebGet(BodyStyle = WebMessageBodyStyle.Bare)]
        Stream Form();
...
 
    public class HelloWorldService : IHelloWorldService
    {
        public Stream Form()
        {
            WebOperationContext.Current.OutgoingResponse.ContentType = 
                   "text/html";
            return new MemoryStream(Encoding.UTF8.GetBytes("A working class hero is something to be "));
        }
