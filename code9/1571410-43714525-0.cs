    private IClientService _ClientService ;
        public IClientService ClientServiceObj
        {
            get
            {
                return _ClientService ??
                       (_ClientService = DependencyResolver.Current.GetService<IClientService>());
            }
            set { _ClientService = value; }
        }
