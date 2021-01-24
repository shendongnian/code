    public class BaseMessage
    {
        public string Data { get; set; }
    }
    public class ChildMessage : BaseMessage
    {
        public string ChildData { get ;set; }
    }
    public abstract class BaseActor : ReceiveActor
    {
        private string baseData;
        public BaseActor()
        {
            Receive<BaseMessage>(m => {
                ProcessMessage(m);
            });
            // be aware that adding ReceiveAny handler in base class means that you wont be able to add any handlers in descendant actors
            // just override Unhandled method instead
        }
        protected virtual void ProcessMessage(BaseMessage m)
        {
            baseData = m.Data;
        }
    }
    public class MyActor: BaseActor
    {
        private string myData;    
        
        public MyActor()
        {
            // no interceptor for ChildMessage here, because parent class has interceptor for BaseMessage and it will handle ChildMessage too
        }
        protected override void ProcessMessage(BaseMessage m)
        {
            base.ProcessMessage(m);
            // not qute OOP way, but it works
            var childMessage = m as ChildMessage;
            if(childMessage != null)
            {
                myData = childMessage.ChildData;
            }
        }
    }
