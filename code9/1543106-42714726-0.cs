    public class CallbackHandler : IServiceBCallback
    {
        OperationContext _context;
        public CallbackHandler(OperationContext context)
        {
            _context = context;
        }
        public void TestProgress(string msg)
        {
            IServiceACallback callback = _context.GetCallbackChannel<IServiceACallback>();
            callback.TestProgress(msg);
        }
    }
