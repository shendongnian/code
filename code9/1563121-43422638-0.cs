    class MainModel : NotifyPropertyChangedBase
    {
        private readonly Dictionary<string, NetworkInterfaceModel> _cache = new Dictionary<string, NetworkInterfaceModel>();
        private IReadOnlyList<NetworkInterfaceModel> _interfaces;
        public IReadOnlyList<NetworkInterfaceModel> Interfaces
        {
            get { return _interfaces; }
            private set { _UpdateField(ref _interfaces, value); }
        }
        public MainModel()
        {
            NetworkChange.NetworkAvailabilityChanged += _OnNetworkAvailabilityChanged;
            _RebuildInterfaceList();
        }
        private void _OnNetworkAvailabilityChanged(object sender, NetworkAvailabilityEventArgs e)
        {
            foreach (NetworkInterfaceModel model in _interfaces)
            {
                if (model.PostEventStatus == PostEventStatus.Removed)
                {
                    _cache.Remove(model.Name);
                }
                else
                {
                    // Assume removed, until proven otherwise while rebuilding list
                    model.SetRemoved();
                }
            }
            _RebuildInterfaceList();
        }
        private void _RebuildInterfaceList()
        {
            foreach (NetworkInterface networkInterface in NetworkInterface.GetAllNetworkInterfaces())
            {
                NetworkInterfaceModel model;
                if (!_cache.TryGetValue(networkInterface.Name, out model))
                {
                    model = new NetworkInterfaceModel(networkInterface);
                    _cache.Add(model.Name, model);
                }
                else
                {
                    model.Reset();
                    model.OperationalStatus = networkInterface.OperationalStatus;
                }
            }
            Interfaces = Array.AsReadOnly(_cache.Values.OrderBy(m => m.Name).ToArray());
        }
    }
