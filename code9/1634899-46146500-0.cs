    public class MyRequest : IRequiresRequestStream
    {
        public Stream RequestStream { get; set; }
    }
    public class MyServices : Service
    {
        public object Any(MyRequest request)
        {
            var bytes = request.RequestStream.ReadFully();
            var text = bytes.FromUtf8Bytes();
            ...
        }
    }
