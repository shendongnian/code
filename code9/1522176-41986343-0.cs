    public class MyPipelineModule : HubPipelineModule
    {
        protected override bool OnBeforeIncoming(IHubIncomingInvokerContext context)
        {
            //context.Args
            //context.Hub
            //context.MethodDescriptor.Name
            return base.OnBeforeIncoming(context);
        }
    }
