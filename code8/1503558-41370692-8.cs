    internal abstract class BaseTransaction<T> : IDisposable where T : class, ITransaction
    {
        private T _opcClient;
        protected T OpcClient
        {
            get { return _opcClient; }
            set
            {
                if (_opcClient != value)
                {
                    OnOpcClientChanging();
                    _opcClient = value;
                    OnOpcClientChanged();
                }
            }
        }
        
        private void OnOpcClientPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "Response":
                    ProcessResponse(OpcClient.Response);
                    break;
                case "Request":
                    ProcessRequest(OpcClient.Request);
                    break;
            }
        }
        protected abstract void ProcessResponse(short opcClientResponse);
        protected abstract void ProcessRequest(bool opcClientRequest);
        private void OnOpcClientChanged()
        {
            if (_opcClient != null)
            {
                _opcClient.PropertyChanged += OnOpcClientPropertyChanged;
                OpcManager = new OpcManager(_opcClient);
            }
        }
        private void OnOpcClientChanging()
        {
            if (_opcClient != null)
                _opcClient.PropertyChanged -= OnOpcClientPropertyChanged;
        }
    }
