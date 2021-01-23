    public class ActionFlowExecution<TResult, TRepository> : IDisposable
    {
        private TRepository _repository;
        internal ActionFlowExecution(TResult result, TRepository repository)
        {
            Result = result;
            _repository = repository;
        }
        public TResult Result { get; private set; }
        public void Dispose()
        {
            if(_repository != null)
            {
                _repository.Dispose();
                _repository = null;
            }
        }
    }
