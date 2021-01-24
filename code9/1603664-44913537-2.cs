    public class InspectorProperty : IContextProperty,
        IContributeObjectSink
    {
        public bool IsNewContextOK(Context newCtx) => true;
    
        public void Freeze(Context newContext)
        {
        }
    
        public string Name { get; } = "LOL";
    
        public IMessageSink GetObjectSink(MarshalByRefObject o,IMessageSink next) => new InspectorAspect(next);
    }
