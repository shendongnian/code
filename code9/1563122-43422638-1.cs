    enum PostEventStatus
    {
        Added,
        NoChange,
        Changed,
        Removed
    }
    class NetworkInterfaceModel : NotifyPropertyChangedBase
    {
        private string _name;
        private OperationalStatus _status;
        private PostEventStatus _postEventStatus = PostEventStatus.Added;
        public NetworkInterfaceModel(NetworkInterface networkInterface)
        {
            _name = networkInterface.Name;
            _status = networkInterface.OperationalStatus;
        }
        public string Name
        {
            get { return _name; }
            set { _UpdateField(ref _name, value); }
        }
        public OperationalStatus OperationalStatus
        {
            get { return _status; }
            set { _UpdateField(ref _status, value, _OnOperationalStatusChanged); }
        }
        public PostEventStatus PostEventStatus
        {
            get { return _postEventStatus; }
            set { _UpdateField(ref _postEventStatus, value); }
        }
        public void Reset()
        {
            PostEventStatus = PostEventStatus.NoChange;
        }
        public void SetRemoved()
        {
            PostEventStatus = PostEventStatus.Removed;
        }
        private void _OnOperationalStatusChanged(OperationalStatus obj)
        {
            PostEventStatus = PostEventStatus.Changed;
        }
    }
