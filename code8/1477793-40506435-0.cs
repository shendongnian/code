    public interface IMessage {}
    public class AbstractMessage : IMessage { }
    // your generic
    public class MessageWrapper<T> where T : IMessage { public T Message { get; set; } }
    // my factory
    [XmlInclude(typeof(ConnectMessage))]
    public class MessageWrapper { public AbstractMessage Message { get; set; } }
    // overrides
    public static class MessageWrapperTester {
        public static XmlAttributeOverrides XmlOverrides {
            get {
                var xmlOverrides = new XmlAttributeOverrides(); 
                var attr = new XmlAttributes();
                attr.XmlElements.Add(new XmlElementAttribute("Connect", typeof(ConnectMessage)));
                xmlOverrides.Add(typeof(MessageWrapper), "Message", attr);
                xmlOverrides.Add(typeof(MessageWrapper<>), "Message", attr);
                xmlOverrides.Add(typeof(MessageWrapper<ConnectMessage>), "Message", attr);
                return xmlOverrides;
            } } }
    // use it like, generic 1st, factory 2nd:
    var srlz = new XmlSerializer(typeof(MessageWrapper<ConnectMessage>), MessageWrapperTester.XmlOverrides);
    var srlz = new XmlSerializer(typeof(MessageWrapper), MessageWrapperTester.XmlOverrides);
    
