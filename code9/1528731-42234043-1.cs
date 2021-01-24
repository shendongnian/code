    public class SendEnqueueInfoProcessor : EnqueueInfoProcessor<DataSendEnqeueInfo>
    {
        SendEnqueueInfoProcessor(CancellationToken token)
            : base(token)
        {
            
        }
        protected override void ProcessItem(DataSendEnqeueInfo item)
        {
            // send logic here
        }
    }
    public class RecievedEnqueueInfoProcessor : EnqueueInfoProcessor<DataRecievedEnqeueInfo>
    {
        RecievedEnqueueInfoProcessor(CancellationToken token)
            : base(token)
        {
        }
        protected override void ProcessItem(DataRecievedEnqeueInfo item)
        {
            // recieve logic here
        }
    }
