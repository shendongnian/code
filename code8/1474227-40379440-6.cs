    internal class LoggingOperationInvoker : IOperationInvoker
    {
        private readonly IOperationInvoker _baseInvoker;
        private readonly string _operationName;
        public LoggingOperationInvoker(IOperationInvoker baseInvoker, DispatchOperation operation)
        {
            _baseInvoker = baseInvoker;
            _operationName = operation.Name;
        }
        public bool IsSynchronous
        {
            get { return _baseInvoker.IsSynchronous; }
        }
        public object[] AllocateInputs()
        {
            return _baseInvoker.AllocateInputs();
        }
        public object Invoke(object instance, object[] inputs, out object[] outputs)
        {
            var sw = new Stopwatch();
            try
            {
                LogBegin();
                sw.Start();
                var response = _baseInvoker.Invoke(instance, inputs, out outputs);
                return response;
            }
            finally
            {
                sw.Stop();
                LogEnd(sw.Elapsed);
            }
        }
        private void LogBegin()
        {
            //you can log begin here.
        }
        private void LogEnd(TimeSpan elapsed)
        {
            //you can log end here.
        }
        public IAsyncResult InvokeBegin(object instance, object[] inputs, AsyncCallback callback, object state)
        {
            return _baseInvoker.InvokeBegin(instance, inputs, callback, state);
        }
        public object InvokeEnd(object instance, out object[] outputs, IAsyncResult result)
        {
            return _baseInvoker.InvokeEnd(instance, out outputs, result);
        }
    }
