        IService _service;
        IUnityContainer _container;
        public DefaultController(IService service,IUnityContainer container)
        {
            _service = service;
            _container = container;
        }
        [HttpGet]
        public async Task<ResponseObject> Test()
        {
            var localService = _container.Resolve<IService>();
            if (Object.ReferenceEquals(_service, localService))
                Debug.WriteLine("Equal");
            else
                Debug.WriteLine("Not Equal");
        }
